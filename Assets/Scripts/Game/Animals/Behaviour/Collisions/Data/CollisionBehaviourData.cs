using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Data
{
    [Serializable]
    public sealed class CollisionBehaviourData : ICollisionBehaviourData
    {
        [SerializeField] private float wallRedirectAngleThreshold = 120f;
        
        public float WallRedirectAngleThreshold => wallRedirectAngleThreshold;
        public Transform Transform { get; private set; }
        public Action<Vector2> OnBlockedByObstacle { get; private set; }
        
        public void Initialize(Transform transform, Action<Vector2> onBlockedByObstacle)
        {
            Transform = transform;
            OnBlockedByObstacle = onBlockedByObstacle;
        }
    }
}