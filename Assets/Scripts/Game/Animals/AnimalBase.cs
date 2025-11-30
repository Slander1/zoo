using System;
using Game.Animals.Behaviour.Collisions;
using Game.Animals.Behaviour.Movers;
using UnityEngine;

namespace Game.Animals
{
    public abstract class AnimalBase : MonoBehaviour
    {
        public event Action<AnimalBase> Died;
        
        [SerializeField] protected AnimalView view;
        
        protected IMover Mover;
        protected IAnimalCollisionBehaviour CollisionBehaviour;
        
        #region === Unity Events ===

        private void Awake()
        {
            InitializeMover();
            InitializeCollisionBehaviour();
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
            CollisionBehaviour.Collision(collision);
        }
        
        protected abstract void InitializeMover();
        protected abstract void InitializeCollisionBehaviour();

        protected void Die()
        {
            Died?.Invoke(this);
        }
    }
}