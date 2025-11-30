using System;
using Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromPray;
using Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromWall;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Controllers.Data
{
    [Serializable]
    public sealed class CollisionControllerDataBase : ICollisionControllerData
    {
        [SerializeField] private RedirectFromWallCollisionBehaviourData redirectFromWallCollisionBehaviourData;
        [SerializeField] private RedirectFromPrayData redirectFromPrayData;
        
        public RedirectFromWallCollisionBehaviourData RedirectFromWallCollisionBehaviourData => redirectFromWallCollisionBehaviourData;
        public RedirectFromPrayData RedirectFromPrayData => redirectFromPrayData;

        public void Initialize(Action<Vector2> onBlockedByObstacle, Action<Vector3, float> onRepulsed)
        {
            redirectFromWallCollisionBehaviourData.Initialize(onBlockedByObstacle);
            redirectFromPrayData.Initialize(onRepulsed);
        }
    }
}