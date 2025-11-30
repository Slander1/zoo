using Game.Animals.Behaviour.Collisions.Controllers;
using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Collisions.Controllers.Variants;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using Game.Animals.Roles;
using Game.Animals.StateInterfaces;
using UnityEngine;

namespace Game.Animals.Variants.Predators
{
    public abstract class PredatorBase <TMover, TMoverData, TCollisionController, TCollisionData>
        : GenericMovableAnimalBase<TMover, TMoverData, TCollisionController, TCollisionData>, 
            IPredator, ICanEat
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionController : IGenericICollisionController<TCollisionData>, new()
        where TCollisionData : ICollisionControllerData
    {
        [SerializeField] public PredatorView predatorView;
        
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
            Force = UnityEngine.Random.Range(0, 1000);
        }

        public void Eat(IPray pray)
        {
            predatorView.ShowForSecondsAsync();
        }
    }
}