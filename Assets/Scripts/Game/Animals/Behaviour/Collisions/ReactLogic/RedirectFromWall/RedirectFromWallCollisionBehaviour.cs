using System;
using Game.Animals.StateInterfaces;
using Game.GameField.Builders.Walls;
using Game.ObjectOnSceneMarkers;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromWall
{
    public sealed class RedirectFromWallCollisionBehaviour : CollisionReactGenericBase<RedirectFromWallCollisionBehaviourData>, IReactTo<IWall>
    {
        public RedirectFromWallCollisionBehaviour(RedirectFromWallCollisionBehaviourData data) : base(data)
        { }

        public override void ReactTo(IInteractableObjectOnScene reactFrom, InteractableObjectOnScene reactTo)
        {
            if (reactTo is not IWall wall) 
                throw new ArgumentException($"type err, react not a wall , {reactTo.GetType()}");

            RedirectFromWall(wall.CenterPosition, reactFrom);
        }
        
        private void RedirectFromWall(Vector3 wallPos, IInteractableObjectOnScene reactFrom)
        {
            var animalPos = reactFrom.Transform.position;
         
            var directionToWall = (wallPos - animalPos).normalized;
            var viewDir = reactFrom.Transform.transform.forward;
            var angleToWall = Vector3.Angle(viewDir, directionToWall);
         
            if (angleToWall > Data.WallRedirectAngleThreshold)
                return;
         
            var outward3 = (wallPos ).normalized;
            var normal2D = new Vector2(outward3.x, outward3.z);
         
            Data.OnBlockedByObstacle.Invoke(normal2D);
        }
    }
}