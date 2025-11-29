using System;
using Game.Animals.Events;
using UnityEngine;

namespace Game.Animals.Behaviour
{ 
    public sealed class CollisionProvider : IDisposable
    {
        private IAnimalsCreator _animalsCreator;
        
        // private List<AnimalBase> _animalsOnWhichSubscribe;
        
        public CollisionProvider(IAnimalsCreator animalsCreator)
        {
            _animalsCreator = animalsCreator;
            SubscribeOnEvents();
        }
        
        private void SubscribeOnEvents()
        {
            _animalsCreator.AnimalsCreated += OnAnimalsCreated;
        }

        private void UnsubscribeFromEvents()
        {
            _animalsCreator.AnimalsCreated -= OnAnimalsCreated;
        }
        
        private void OnAnimalsCreated(AnimalBase animal)
        {
            animal.CollisionEntered += AnimalOnCollisionEntered;
        }

        private void AnimalOnCollisionEntered(AnimalBase arg1, Collision arg2)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            UnsubscribeFromEvents();
        }
    }
}