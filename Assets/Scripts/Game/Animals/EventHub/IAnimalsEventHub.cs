using System;
using Game.Animals.StatCounters;

namespace Game.Animals.EventHub
{
    public interface IAnimalsEventHub
    {
        event Action<AnimalBase> AnimalSpawned;
        event Action<AnimalBase> AnimalDied;
        event Action<DiedState> DiedStateUpdated;

        void RaiseAnimalSpawned(AnimalBase animal);
        void RaiseAnimalDied(AnimalBase animal);
        void RaiseUpdateDiedState(DiedState state);
    }
}