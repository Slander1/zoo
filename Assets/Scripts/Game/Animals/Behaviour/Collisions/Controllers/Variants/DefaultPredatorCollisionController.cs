using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Collisions.ReactLogic.PredatorEatPrey;
using Game.Animals.Behaviour.Collisions.ReactLogic.PredatorFight;
using Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromWall;
using Game.Animals.Roles;
using Game.GameField.Builders.Walls;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Controllers.Variants
{
    public class DefaultPredatorCollisionController : CollisionControllerGeneric<CollisionControllerDataBase>
    {
        public override void Initialize(CollisionControllerDataBase dataBase)
        {
            base.Initialize(dataBase);
            Reacts.Add(typeof(IWall), new RedirectFromWallCollisionBehaviour(Data.RedirectFromWallCollisionBehaviourData));
            Reacts.Add(typeof(IPredator), new PredatorFightCollisionBehaviour());
            Reacts.Add(typeof(IPray), new PredatorEatPreyBehaviour());
            // Reacts.Add();
        }
    }
}