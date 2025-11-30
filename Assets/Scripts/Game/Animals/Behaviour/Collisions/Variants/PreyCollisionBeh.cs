using Game.Animals.Behaviour.Collisions.InteractionInterfaces;
using Game.Animals.Variants.Predators;

namespace Game.Animals.Behaviour.Collisions.Variants
{
    public sealed class PreyCollisionBeh : CollisionBehaviourBase, IPredatorMarkerInteractable
    {
        public void OnPredatorCollision(IHaveForce haveForce)
        {
            Data.Animal.Die();
        }

        public int Force { get; }
    }
}