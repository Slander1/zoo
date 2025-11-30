using System;
using Game.Animals.Events;
using Game.Animals.Pool;
using Game.Providers;
using UnityEngine;
using VContainer.Unity;

namespace Game.Animals.Behaviour
{ 
    public sealed class CollisionProvider : IStartable, IDisposable
    {
        private readonly IAnimalsCreator _animalsCreator;
        private readonly IGameFieldCenterProvider _gameFieldCenterProvider;
        private readonly IAnimalsHashSetProvider _animalsHashSetProvider;
        
        public CollisionProvider(IAnimalsCreator animalsCreator, 
            IAnimalsHashSetProvider hashSetProvider, IGameFieldCenterProvider  gameFieldCenterProvider)
        {
            _animalsCreator = animalsCreator;
            _animalsHashSetProvider = hashSetProvider;
            _gameFieldCenterProvider = gameFieldCenterProvider;
        }

        void IStartable.Start()
        {
            SubscribeOnEvents();
        }
        
        private void SubscribeOnEvents()
        {
            _animalsCreator.AnimalsCreated += OnAnimalsCreated;
        }

        private void UnsubscribeFromEvents()
        {
            _animalsCreator.AnimalsCreated -= OnAnimalsCreated;
            
            foreach (var animalBase in _animalsHashSetProvider.AnimalsOnField) 
                animalBase.CollisionEntered -= AnimalOnCollisionEntered;
        }
        
        private void OnAnimalsCreated(AnimalBase animal)
        {
            animal.CollisionEntered += AnimalOnCollisionEntered;
        }

        private void AnimalOnCollisionEntered(AnimalBase animal, Collision collision)
        {
            if (!collision.collider.CompareTag("Wall"))
                return;

            var wallPos = collision.transform.position;
            var outward3 = (wallPos - _gameFieldCenterProvider.GetFieldCenter()).normalized;
            var normal2D = new Vector2(outward3.x, outward3.z);
            
            animal.OnBlockedByObstacle(normal2D);
        }

        public void Dispose()
        {
            UnsubscribeFromEvents();
        }
    }
}