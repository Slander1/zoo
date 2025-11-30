using Game.Animals.Behaviour.Collisions;
using Game.Animals.Behaviour.Collisions.Data;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;

namespace Game.Animals.Variants.Prey
{
    public abstract class PreyBase <TMover, TMoverData, TCollisionBeh, TTCollisionBehData> 
        : GenericMovableAnimalBase<TMover, TMoverData, TCollisionBeh, TTCollisionBehData>
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionBeh : IAnimalCollisionBehaviour, new()
        where TTCollisionBehData  : ICollisionBehaviourData
    { }
}