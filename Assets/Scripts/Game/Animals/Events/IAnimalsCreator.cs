using System;

namespace Game.Animals.Events
{
    public interface IAnimalsCreator
    {
        public event Action<AnimalBase> AnimalsCreated;
    }
}