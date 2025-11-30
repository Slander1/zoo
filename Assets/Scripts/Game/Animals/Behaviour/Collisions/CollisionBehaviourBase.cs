using System;
using System.Collections.Generic;
using Game.Animals.Behaviour.Collisions.Data;
using Game.Animals.Behaviour.Collisions.InteractionControllers.Interfaces;
using Game.Animals.Behaviour.Collisions.InteractionInterfaces;
using Game.Utility;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions
{
    public abstract class CollisionBehaviourBase : IGenericCollisionBehaviour<ICollisionBehaviourData>, IWallInteractable
    {
        protected ICollisionBehaviourData Data;
        private readonly Dictionary<Type, IInteractableControllerMarker> _interactableControllers = new(); 
        
        public void Initialize(ICollisionBehaviourData data)
        {
            Data = data;
            InitializeInteractableControllersComponents();
        }
        
        public void OnCollision(Collision collision)
        {
            Data.CollisionDefiner.OnCollision(this, collision);
        }

        private void InitializeInteractableControllersComponents()
        {
            InteractableControllersHelper.RegisterMarkerInterfaces(this, _interactableControllers);
        }
        
        public bool TryGetController<TController>(out TController value) where TController : class, IInteractableControllerMarker
        {
            if (_interactableControllers.TryGetValue(typeof(TController), out var raw))
            {
                value = raw as TController;
                return value != null;
            }

            value = null;
            return false;
        }
        
        public void OnWallCollision(Vector3 wallPos)
        {
            RedirectFromWall(wallPos);
        }
        
        private void RedirectFromWall(Vector3 wallPos)
        {
            var animalPos = Data.Animal.transform.position;
        
            var directionToWall = (wallPos - animalPos).normalized;
            var viewDir = Data.Animal.transform.forward;
            var angleToWall = Vector3.Angle(viewDir, directionToWall);
        
            if (angleToWall > Data.WallRedirectAngleThreshold)
                return;
        
            var outward3 = (wallPos ).normalized;
            var normal2D = new Vector2(outward3.x, outward3.z);
        
            Data.Animal.OnBlockedByObstacle(normal2D);
        }
    }
}