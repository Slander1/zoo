using Game.Animals.Behaviour.Collisions.Data;
using Game.Animals.Behaviour.Collisions.InteractionInterfaces;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions
{
    public interface IAnimalCollisionBehaviour
    {
        public void Initialize(ICollisionBehaviourData data); 
        
        public void OnCollision(Collision collision);
        public bool TryGetController<TController>(out TController value) where TController : class, IInteractableControllerMarker;
    }
}