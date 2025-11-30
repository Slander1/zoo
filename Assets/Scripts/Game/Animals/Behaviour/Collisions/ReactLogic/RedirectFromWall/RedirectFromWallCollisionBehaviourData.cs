using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromWall
{
    [Serializable]
    public class RedirectFromWallCollisionBehaviourData
    {
        [SerializeField] private float wallRedirectAngleThreshold = 120f;
        
        public float WallRedirectAngleThreshold => wallRedirectAngleThreshold;
        public Action<Vector2> OnBlockedByObstacle { get; private set; }

        public void Initialize(Action<Vector2> onBlockedByObstacle)
        {
            OnBlockedByObstacle = onBlockedByObstacle;
        }
    }
}