using System;
using System.Collections.Generic;
using Game.Animals.Events;
using UnityEngine;

namespace Game.Animals.Pool
{
    public sealed class AnimalsPool : IDisposable
    {
        private HashSet<AnimalBase> _animalsOnField = new();
        private HashSet<AnimalBase> _animalsInObjectPool = new();

        private readonly IAnimalsCreator _animalsCreator;
        
        public AnimalsPool(IAnimalsCreator animalsCreator)
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
            _animalsOnField.Add(animal);
        }

        public void Dispose()
        {
            UnsubscribeFromEvents();
        }
        
        public void IsHaveAnimalInObjectPool(AnimalBase animal)
        {
            
        }
        
        public void OnCreateAnimal(AnimalBase animal)
        {
            
        }

        public void OnDestroyAnimalPool(AnimalBase animal)
        {
            
        }
    }
}