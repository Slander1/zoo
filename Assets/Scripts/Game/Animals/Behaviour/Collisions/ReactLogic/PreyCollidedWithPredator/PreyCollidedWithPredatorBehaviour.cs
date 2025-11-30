using Game.Animals.Roles;
using Game.Animals.StateInterfaces;
using Game.ObjectOnSceneMarkers;

namespace Game.Animals.Behaviour.Collisions.ReactLogic.PreyCollidedWithPredator
{
    public class PreyCollidedWithPredatorBehaviour : CollisionReactBase, IReactTo<IPredator>
    {
        public override void ReactTo(IInteractableObjectOnScene reactFrom, InteractableObjectOnScene reactTo)
        {
            if (reactFrom is not IPray pray || reactTo is not IPredator predator)
                throw new System.Exception("PredatorFightCollisionBehaviour reactTo or reactFrom is not IPredator");

            pray.Die();
        }
    }
}