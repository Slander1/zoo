using Game.Animals.Behaviour.Collisions;
using Game.Animals.Behaviour.Collisions.Data;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using Game.Animals.Roles.MarkerInterfaces;

namespace Game.Animals.Variants.Predators
{
    public abstract class PredatorMarkerBase <TMover, TMoverData, TCollisionBeh, TTCollisionBehData> 
        : GenericMovableAnimalBase<TMover, TMoverData, TCollisionBeh, TTCollisionBehData>, IPredatorMarker
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionBeh : IAnimalCollisionBehaviour, new()
        where TTCollisionBehData  : ICollisionBehaviourData
    {
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
    }
}