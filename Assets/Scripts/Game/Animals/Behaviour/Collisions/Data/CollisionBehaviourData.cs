using System;
using Game.Animals.Roles.MarkerInterfaces;
using Game.Animals.Variants.Predators;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.Data
{
    [Serializable]
    public sealed class CollisionBehaviourData : ICollisionBehaviourData
    {
        [SerializeField] private float wallRedirectAngleThreshold = 120f;
        private int _force;

        public float WallRedirectAngleThreshold => wallRedirectAngleThreshold;
        public AnimalBase Animal { get; private set;}
        public CollisionDefiner CollisionDefiner { get; private set; }
        
        public void Initialize(AnimalBase animalBase, CollisionDefiner collisionDefiner)
        {
            Animal =  animalBase;
            CollisionDefiner = collisionDefiner;
        }
    }
}