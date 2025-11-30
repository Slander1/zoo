using Game.Animals.Roles;
using Game.Animals.StateInterfaces;
using Game.ObjectOnSceneMarkers;

namespace Game.Animals.Behaviour.Collisions.ReactLogic.PredatorFight
{
    public class PredatorFightCollisionBehaviour : CollisionReactBase, IReactTo<IPredator>
    {
        public override void ReactTo(IInteractableObjectOnScene reactFrom, InteractableObjectOnScene reactTo)
        {
            if (reactTo is not IPredator attackedPredator || reactFrom is not IPredator attackingPredator)
                throw new System.Exception("PredatorFightCollisionBehaviour reactTo or reactFrom is not IPredator");

            if (attackedPredator.Force > attackingPredator.Force)
                attackedPredator.Die();
            else
                attackingPredator.Eat();
        }
    }
}