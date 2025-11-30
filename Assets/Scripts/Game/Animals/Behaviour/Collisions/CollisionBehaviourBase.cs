using Game.Animals.Behaviour.Collisions.Data;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions
{
    public abstract class CollisionBehaviourBase : IGenericCollisionBehaviour<ICollisionBehaviourData>
    {
        private ICollisionBehaviourData _data;
        
        public void Initialize(ICollisionBehaviourData data)
        {
            _data = data;
        }
        
        public void Collision(Collision collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                var wallPos = collision.transform.position;
                RedirectFromWall(wallPos);
                return;
            }
        }

        public abstract void OnWallCollision(float wall);

        public abstract void OnPreyCollision(Collision collision);

        public abstract void OnPredatorCollision(Collision collision);

        private void RedirectFromWall(Vector3 wallPos)
        {
            var animalPos = _data.Transform.position;

            var directionToWall = (wallPos - animalPos).normalized;
            var viewDir = _data.Transform.forward;
            var angleToWall = Vector3.Angle(viewDir, directionToWall);

            if (angleToWall > _data.WallRedirectAngleThreshold)
                return;

            var outward3 = (wallPos ).normalized;
            var normal2D = new Vector2(outward3.x, outward3.z);

            _data.OnBlockedByObstacle.Invoke(normal2D);
        }
    }
}