using System;
using System.Collections.Generic;
using Game.Animals.Behaviour.Collisions;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Roles.MarkerInterfaces;
using Game.Utility;
using UnityEngine;

namespace Game.Animals
{
    public abstract class AnimalBase : MonoBehaviour
    {
        public Dictionary<Type, IRoleMarker> Roles = new();
        
        public event Action<AnimalBase> Died;
        
        [SerializeField] protected AnimalView view;
        
        protected IMover Mover;
        protected IAnimalCollisionBehaviour CollisionBehaviour;
        protected CollisionDefiner CollisionDefiner;
        
        #region === Unity Events ===

        protected virtual void Awake()
        {
            CollisionDefiner = new CollisionDefiner();
            
            InitializeMover();
            InitializeCollisionBehaviour();
            InitializeInteractableControllersComponents();
        }

        private void OnEnable()
        {
            Mover.StartMove();
            view.CollisionEntered += OnViewCollisionEnter;
        }

        private void OnDisable()
        {
            Mover.StopMove();
            view.CollisionEntered -= OnViewCollisionEnter;
        }

        #endregion === Unity Events ===

        public float GetObjectHeight()
        {
            return view.GetObjectHeight();
        }

        public void OnBlockedByObstacle(Vector2 obstacleNormal)
        {
            Mover.OnBlockedByObstacle(obstacleNormal);
        }
        
        private void OnViewCollisionEnter(Collision collision)
        {
            CollisionBehaviour.OnCollision(collision);
        }
        
        protected abstract void InitializeMover();
        protected abstract void InitializeCollisionBehaviour();

        public void Die()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
        
        protected void InitializeInteractableControllersComponents()
        {
            InteractableControllersHelper.RegisterMarkerInterfaces(this, Roles);
        }
    }
}