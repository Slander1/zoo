namespace Game.Animals.Behaviour.Movers
{
    public interface IGenericMover<TData> : IMover
    {
        public void Initialize(TData data);
    }
}