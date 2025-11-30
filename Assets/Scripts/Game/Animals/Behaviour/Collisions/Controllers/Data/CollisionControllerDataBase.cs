using System;
using Game.Animals.Behaviour.Collisions.ReactLogic.PredatorFight;
using Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromWall;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Controllers.Data
{
    [Serializable]
    public sealed class CollisionControllerDataBase : ICollisionControllerData
    {
        [SerializeField] private RedirectFromWallCollisionBehaviourData redirectFromWallCollisionBehaviourData;
        public RedirectFromWallCollisionBehaviourData RedirectFromWallCollisionBehaviourData => redirectFromWallCollisionBehaviourData;

        public void Initialize(Action<Vector2> onBlockedByObstacle)
        {
            redirectFromWallCollisionBehaviourData.Initialize(onBlockedByObstacle);
        }
    }
}