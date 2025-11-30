using Game.Animals.Roles;
using Game.Animals.StateInterfaces;
using Game.ObjectOnSceneMarkers;

namespace Game.Animals.Behaviour.Collisions.ReactLogic.PredatorEatPrey
{
    public class PredatorEatPreyBehaviour : CollisionReactBase, IReactTo<IPray>
    {
        public override void ReactTo(IInteractableObjectOnScene reactFrom, InteractableObjectOnScene reactTo)
        {
            if (reactFrom is not IPredator attackingPredator || reactTo is not IPray pray)
                throw new System.Exception("PredatorFightCollisionBehaviour reactTo or reactFrom is not IPredator");
            
            attackingPredator.Eat(pray);
        }
    }
}