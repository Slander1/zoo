namespace Game.Animals.Behaviour.Collisions.Controllers
{
    public interface IGenericICollisionController<in TData> : ICollisionController
    {
        public void Initialize(TData data);
    }
}