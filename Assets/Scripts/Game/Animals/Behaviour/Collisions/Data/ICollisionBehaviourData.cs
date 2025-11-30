using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Data
{
    public interface ICollisionBehaviourData
    {
        public float WallRedirectAngleThreshold { get; }
        public AnimalBase Animal { get; }
        public CollisionDefiner CollisionDefiner { get; }
        
        public void Initialize(AnimalBase animalBase, CollisionDefiner collisionDefiner);
    }
}