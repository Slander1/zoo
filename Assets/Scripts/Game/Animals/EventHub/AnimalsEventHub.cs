using System;
using System.Collections.Generic;
using Game.Animals.StatCounters;

namespace Game.Animals.EventHub
{
    public sealed class AnimalsEventHub : IAnimalsEventHub, IDisposable
    {
        public event Action<AnimalBase> AnimalSpawned;
        public event Action<AnimalBase> AnimalDied;
        
        public event Action<DiedState> DiedStateUpdated;

        private readonly List<AnimalBase> _subOnAnimals = new();
        
        public void RaiseAnimalSpawned(AnimalBase animal)
        {
            AnimalSpawned?.Invoke(animal);
            _subOnAnimals.Add(animal);
            animal.Died += RaiseAnimalDied;
        }

        public void RaiseAnimalDied(AnimalBase animal)
        {
            AnimalDied?.Invoke(animal);
            animal.Died -= RaiseAnimalDied;
            _subOnAnimals.Remove(animal);
        }

        public void RaiseUpdateDiedState(DiedState state)
        { 
            DiedStateUpdated?.Invoke(state);
        }

        public void Dispose()
        {
            foreach (var animal in _subOnAnimals) animal.Died -= RaiseAnimalDied;
        }
    }
}