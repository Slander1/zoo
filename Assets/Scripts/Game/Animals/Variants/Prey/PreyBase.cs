using Game.Animals.Behaviour.Collisions.Controllers;
using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Collisions.Controllers.Variants;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using Game.Animals.Roles;

namespace Game.Animals.Variants.Prey
{
    public abstract class PreyBase<TMover, TMoverData,  TCollisionController, TCollisionData>
        : GenericMovableAnimalBase<TMover, TMoverData, TCollisionController, TCollisionData>, IPray
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionController : IGenericICollisionController<TCollisionData>, new()
        where TCollisionData : ICollisionControllerData
    {
    }
}