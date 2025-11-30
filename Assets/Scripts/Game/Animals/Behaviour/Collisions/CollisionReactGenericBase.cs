namespace Game.Animals.Behaviour.Collisions
{
    public abstract class CollisionReactGenericBase<TData>  : CollisionReactBase
    {
        protected readonly TData Data;

        protected CollisionReactGenericBase(TData data)
        {
            Data = data;
        }
    }
}