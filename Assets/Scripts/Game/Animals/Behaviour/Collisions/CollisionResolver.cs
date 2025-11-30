using UnityEngine;

namespace Game.Animals.Behaviour.Collisions
{
    public sealed class CollisionResolver
    {
        public void Collision(AnimalView view, Collision collision)
        {
            if (collision.gameObject.activeSelf == false) return;
            
            
        }
    }
}