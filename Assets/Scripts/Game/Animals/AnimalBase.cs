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
        protected CollisionDefiner CollisionDefiner;
        
        #region === Unity Events ===

        protected virtual void Awake()
        {
            CollisionDefiner = new CollisionDefiner();
            
            InitializeMover();
            InitializeCollisionController();
        }
        
        // public void Initialize(ICollisionBehaviourData data)
        // {
        //     // Регистрируем реакции
        //     ReactedTo[typeof(IWall)] = ReactTo;
        //     ReactedTo[typeof(PreyAnimal)]   = OnPreyReaction;
        // }


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
            CollisionDefiner.OnCollision(this, collision);
            // CollisionBehaviour.OnCollision(collision);
        }
        
        protected abstract void InitializeMover();
        // protected abstract void InitializeCollisionBehaviour();

        public void Die()
        {
            Died?.Invoke(this);
        }

        protected abstract void InitializeCollisionController();
    }
}