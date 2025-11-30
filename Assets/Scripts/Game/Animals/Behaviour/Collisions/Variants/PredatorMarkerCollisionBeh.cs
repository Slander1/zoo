using Game.Animals.Behaviour.Collisions.InteractionInterfaces;
using Game.Animals.Variants.Predators;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Variants
{
    public class PredatorMarkerCollisionBeh : CollisionBehaviourBase, IPredatorMarkerInteractable, IPrayInteractable
    {
        public void OnPredatorCollision(IHaveForce haveForce)
        {
            var componentHaveForce = Data.Animal as IHaveForce;
            var myForce = 0;
            
            if (componentHaveForce != null)
            {
                myForce = componentHaveForce.Force;
            }

            if (myForce >= haveForce.Force)
            {
                Debug.Log("good");
            }
            else
            {
                Data.Animal.Die();
            }
        }

        public void OnPreyCollision(AnimalBase animalBase)
        {
            Debug.Log("Yumi");
        }
    }
}