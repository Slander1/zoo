using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Animals.Behaviour.Movers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Animals
{
    public abstract class AnimalBase : MonoBehaviour
    {
        public event Action<AnimalBase, Collision> CollisionEntered;
        
        [SerializeField] protected AnimalView view;
        [SerializeField] protected float moveSpeed = 2f;

        protected IMover Mover;
        
        #region === Unity Events ===

        private void Awake()
        {
            InitializeMover();
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
            CollisionEntered?.Invoke(this, collision);
        }
        
        protected abstract void InitializeMover();
    }
}