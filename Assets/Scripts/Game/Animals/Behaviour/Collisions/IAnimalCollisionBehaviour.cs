using Game.Animals.Behaviour.Collisions.Data;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions
{
    public interface IAnimalCollisionBehaviour
    {
        public void Initialize(ICollisionBehaviourData data); 
        
        public void Collision(Collision collision);

        public void OnWallCollision(float wall);
        public void OnPreyCollision(Collision collision);
        public void OnPredatorCollision(Collision collision);
    }
}