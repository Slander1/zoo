using Game.Animals.Behaviour.Collisions.Controllers;
using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using Game.Animals.Roles;
using UnityEngine;

namespace Game.Animals.Variants.Predators
{
    public abstract class PredatorBase <TMover, TMoverData, TCollisionController, TCollisionData>
        : GenericMovableAnimalBase<TMover, TMoverData, TCollisionController, TCollisionData>, 
            IPredator
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionController : IGenericICollisionController<TCollisionData>, new()
        where TCollisionData : ICollisionControllerData
    {
        [SerializeField] public PredatorTastyView predatorTastyView;
        
        public int Force { get; protected set; }

        #region === Unity Events ===

        protected override void Awake()
        {
            base.Awake();
            SetRandomForce();
        }

        #endregion === Unity Events ===

        private void SetRandomForce()
        {
            Force = Random.Range(0, 1000);
        }

        public void Eat()
        {
            predatorTastyView.ShowForSecondsAsync();
        }
    }
}