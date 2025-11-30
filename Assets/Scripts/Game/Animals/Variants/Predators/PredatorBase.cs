using Game.Animals.Behaviour.Collisions;
using Game.Animals.Behaviour.Collisions.Data;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;

namespace Game.Animals.Variants.Predators
{
    public abstract class PredatorBase <TMover, TMoverData, TCollisionBeh, TTCollisionBehData> 
        : GenericMovableAnimalBase<TMover, TMoverData, TCollisionBeh, TTCollisionBehData>
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionBeh : IAnimalCollisionBehaviour, new()
        where TTCollisionBehData  : ICollisionBehaviourData,
        IHaveForce
    {
        public int Force { get; protected set; }

        protected void SetRandomForce()
        {
            Force = UnityEngine.Random.Range(0, 1000);
        }
    }
}