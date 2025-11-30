using Game.Animals.Roles.MarkerInterfaces;
using Game.Animals.Variants.Predators;

namespace Game.Animals.Behaviour.Collisions.InteractionInterfaces
{
    public interface IPredatorMarkerInteractable : IInteractableControllerMarker
    {
        public void OnPredatorCollision(IHaveForce haveForce);
    }
}