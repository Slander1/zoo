using Game.Animals.EventHub;
using Game.Animals.StatCounters;
using UnityEngine;
using VContainer;

namespace Game.UI.UpPanel
{
    public sealed class UpPanelPresenter : MonoBehaviour
    {
        [SerializeField] private PrayCountView prayCountView;
        [SerializeField] private PredatorCountView predatorCountView;

        private IAnimalsEventHub _animalsEventHub;
        
        [Inject]
        public void Construct(IAnimalsEventHub animalsEventHub)
        {
            _animalsEventHub = animalsEventHub;
        }
        
        #region === Unity Events ===

        private void OnEnable()
        {
            _animalsEventHub.DiedStateUpdated += AnimalsEventHubOnDiedStateUpdated;
        }

        private void OnDisable()
        {
            _animalsEventHub.DiedStateUpdated -= AnimalsEventHubOnDiedStateUpdated;
        }

        #endregion === Unity Events ===
        
        private void AnimalsEventHubOnDiedStateUpdated(DiedState state)
        {
            prayCountView.UpdateCount(state.PreyDiedCount);
            predatorCountView.UpdateCount(state.PredatorDiedCount);
        }
    }
}