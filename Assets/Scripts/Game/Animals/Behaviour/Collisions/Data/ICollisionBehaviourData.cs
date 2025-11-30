using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Data
{
    public interface ICollisionBehaviourData
    {
        public float WallRedirectAngleThreshold { get; }
        
        public Transform Transform { get; }
        public Action<Vector2> OnBlockedByObstacle { get; }

        public void Initialize(Transform transform, Action<Vector2> onBlockedByObstacle);
    }
}