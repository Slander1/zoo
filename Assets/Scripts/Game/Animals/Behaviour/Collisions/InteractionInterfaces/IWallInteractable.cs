using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.InteractionInterfaces
{
    public interface IWallInteractable : IInteractableControllerMarker
    {
        public void OnWallCollision(Vector3 wallPos);
    }
}