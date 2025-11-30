using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;

namespace Game.Animals.Variants.Prey
{
    public abstract class PreyBase <TMover, TData> : GenericMovableAnimalBase<TMover, TData>
        where TMover : IGenericMover<TData>, new()
        where TData  : IMoverData
    { }
}