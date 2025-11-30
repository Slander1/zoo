using System;
using Game.Animals.EventHub;
using VContainer.Unity;

namespace Game.Animals.StatCounters
{
    public sealed class DiedCounter : IStartable, IDisposable
    {
        private readonly DiedState _diedState = new();
        private readonly IAnimalsEventHub _eventHub;
        
        public DiedCounter(IAnimalsEventHub eventHub)
        {
            _eventHub = eventHub;
        }
        
        void IStartable.Start()
        {
            SubscribeOnEvents();
        }
        
        private void AnimalOnDied(AnimalBase animal)
        {
            _diedState.Update(animal);
            _eventHub.RaiseUpdateDiedState(_diedState);
        }

        #region === Subsriprions ===

        private void SubscribeOnEvents()
        {
            _eventHub.AnimalDied += AnimalOnDied;
        }

        private void UnsubscribeFromEvents()
        {
            _eventHub.AnimalDied -= AnimalOnDied;
        }
        
        #endregion === Subsriprions ===
        
        public void Dispose()
        {
            UnsubscribeFromEvents();
        }
    }
}