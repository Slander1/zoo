using System.Linq;
using Game.Animals.StateInterfaces;
using Game.ObjectOnSceneMarkers;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions
{
    public sealed class CollisionDefiner
    {
        public void OnCollision(
            InteractableObjectOnScene interactableElementFrom,
            Collision collision)
        {
            if (interactableElementFrom is not IHaveCollisionController collisionController)
                return;
            
            if (!collision.collider.TryGetComponent<InteractableObjectOnScene>(out var interactableElementTo))
                return;

            var toType = interactableElementTo.GetType();

            var interactableInterfaces = toType
                .GetInterfaces()
                .Where(i => typeof(IInteractableObjectOnScene).IsAssignableFrom(i)
                            && i != typeof(IInteractableObjectOnScene))
                .ToArray();

            foreach (var interactableInterface in interactableInterfaces)
            {
                if (collisionController.CollisionController.TryGetCollisionReact(interactableInterface, out var react))
                    react.ReactTo(interactableElementFrom, interactableElementTo);
            }
        }
    }
}