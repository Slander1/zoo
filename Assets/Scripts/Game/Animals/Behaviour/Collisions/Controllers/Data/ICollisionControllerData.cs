using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Controllers.Data
{
    public interface ICollisionControllerData
    {
        public void Initialize(Action<Vector2> onBlockedByObstacle, Action<Vector3, float> onRepulsed);
    }
}