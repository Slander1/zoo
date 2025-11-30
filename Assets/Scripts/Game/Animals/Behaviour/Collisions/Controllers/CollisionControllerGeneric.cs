using Game.Animals.Behaviour.Collisions.Controllers.Data;

namespace Game.Animals.Behaviour.Collisions.Controllers
{
    public class CollisionControllerGeneric<TData> : CollisionControllerBase, IGenericICollisionController<TData> where TData : ICollisionControllerData
    {
        protected TData Data;
        
        public virtual void Initialize(TData data)
        {
            Data = data;
        }
    }
}