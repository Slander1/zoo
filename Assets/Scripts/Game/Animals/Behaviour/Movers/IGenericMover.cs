using Game.Animals.StateInterfaces;

namespace Game.Animals.Behaviour.Movers
{
    public interface IGenericMover<in TData> : IMover
    {
        public void Initialize(TData data);
    }
}