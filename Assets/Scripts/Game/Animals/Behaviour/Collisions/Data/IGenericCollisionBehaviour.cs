namespace Game.Animals.Behaviour.Collisions.Data
{
    public interface IGenericCollisionBehaviour<in TData> : IAnimalCollisionBehaviour
    {
        public void Initialize(TData data);
    }
}