using Game.Animals.StateInterfaces;
using UnityEngine;

namespace Game.Animals.Behaviour.Movers
{
    public interface IMover : IRepulsable
    {
        public void StartMove();
        public void StopMove();
        public void OnBlockedByObstacle(Vector2 obstacleNormal);
    }
}