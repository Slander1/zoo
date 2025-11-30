using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Collisions.ReactLogic.PreyCollidedWithPredator;
using Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromWall;
using Game.Animals.Roles;
using Game.GameField.Builders.Walls;

namespace Game.Animals.Behaviour.Collisions.Controllers.Variants
{
    public sealed class DefaultPreyCollisionController : CollisionControllerGeneric<CollisionControllerDataBase>
    {
        public override void Initialize(CollisionControllerDataBase dataBase)
        {
            base.Initialize(dataBase);
            Reacts.Add(typeof(IWall), new RedirectFromWallCollisionBehaviour(Data.RedirectFromWallCollisionBehaviourData));
            Reacts.Add(typeof(IPredator), new PreyCollidedWithPredatorBehaviour());
        }
    }
}