using System.Collections.Generic;

namespace Game.Animals.Pool
{
    public interface IAnimalsHashSetProvider
    {
        public HashSet<AnimalBase> AnimalsOnField { get; }
    }
}