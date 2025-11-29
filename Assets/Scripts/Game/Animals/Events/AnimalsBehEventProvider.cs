using System;
using UnityEngine;

namespace Game.Animals.Events
{
    public sealed class AnimalsBehEventProvider
    {
        public event Action<AnimalBase> AnimalCreated;
        public event Action<AnimalBase> AnimalDestroyed;
        
        public event Action<AnimalBase, Collision> CollisionEntered;
    }
}