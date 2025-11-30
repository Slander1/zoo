using Game.Animals.Roles.MarkerInterfaces;

namespace Game.Animals.Behaviour.Collisions.InteractionInterfaces
{
    public interface IPrayInteractable : IInteractableControllerMarker
    {
        public void OnPreyCollision(AnimalBase animalBase);
    }
}