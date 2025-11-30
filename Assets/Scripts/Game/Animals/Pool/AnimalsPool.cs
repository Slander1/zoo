using System;
using System.Collections.Generic;
using Game.Animals.EventHub;
using Game.Providers;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Game.Animals.Pool
{
    public sealed class AnimalsPool : IStartable, IDisposable, IObjectPoolProvider
    {
        private readonly HashSet<AnimalBase> _animalsInObjectPool = new();

        private readonly Transform _objectPoolParent;
        private readonly IAnimalsEventHub _eventHub;
        
        public AnimalsPool(IAnimalsEventHub eventHub)
        {
            _objectPoolParent = new GameObject("ObjectPool").transform;
            _objectPoolParent.position = new Vector3(0f, 50f, 0f);
            _eventHub = eventHub;
        }
        
        void IStartable.Start()
        {
            SubscribeOnEvents();
        }
        
        public bool TryGetElemFromObjectPool(out AnimalBase animal)
        {
            animal = null;
            if (_animalsInObjectPool.Count == 0) return false;
            
            var index = Random.Range(0, _animalsInObjectPool.Count);
            var i = 0;

            foreach (var objPoolAnimal in _animalsInObjectPool)
            {
                if (i == index)
                {
                    animal = objPoolAnimal;
                }
                i++;
            }

            if (animal == null)
            {
                return false;
            }

            animal.gameObject.SetActive(true);
            _animalsInObjectPool.Remove(animal);
            return true;
        }
        
        private void SubscribeOnEvents()
        {
            _eventHub.AnimalDied += AnimalOnDied;
        }
        
        private void UnsubscribeFromEvents()
        {
            _eventHub.AnimalDied -= AnimalOnDied;
        }
        
        private void AnimalOnDied(AnimalBase animal)
        {
            animal.Died -= AnimalOnDied;
            _animalsInObjectPool.Add(animal);
            
            animal.transform.SetParent(_objectPoolParent);
            animal.gameObject.SetActive(false);
            animal.transform.position = Vector3.zero;
        }

        public void Dispose()
        {
            UnsubscribeFromEvents();
        }
    }
}