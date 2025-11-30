using UnityEngine;

namespace Game.Animals.Behaviour.Movers
{
    public interface IMover
    {
        public void StartMove();
        public void StopMove();
        public void OnBlockedByObstacle(Vector2 obstacleNormal);
    }
}