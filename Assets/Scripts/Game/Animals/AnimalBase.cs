using System;
using Game.Animals.Behaviour.Collisions;
using Game.Animals.Behaviour.Collisions.Controllers;
using Game.Animals.Behaviour.Movers;
using Game.Animals.StateInterfaces;
using Game.ObjectOnSceneMarkers;
using UnityEngine;

namespace Game.Animals
{
    public abstract class AnimalBase : InteractableObjectOnScene, IHaveCollisionController
    {
        public ICollisionController CollisionController { get; protected set; }
        
        public event Action<AnimalBase> Died;
        
        [SerializeField] protected AnimalView view;
        
        protected IMover Mover;
        private CollisionDefiner _collisionDefiner;
        
        #region === Unity Events ===

        protected virtual void Awake()
        {
            _collisionDefiner = new CollisionDefiner();
            
            InitializeMover();
            InitializeCollisionController();
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

        protected void OnBlockedByObstacle(Vector2 obstacleNormal)
        {
            Mover.OnBlockedByObstacle(obstacleNormal);
        }
        
        private void OnViewCollisionEnter(Collision collision)
        {
            _collisionDefiner.OnCollision(this, collision);
        }
        
        protected abstract void InitializeMover();

        public void Die()
        {
            Died?.Invoke(this);
        }

        protected abstract void InitializeCollisionController();
    }
}