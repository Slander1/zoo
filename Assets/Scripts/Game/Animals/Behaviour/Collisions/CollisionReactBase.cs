using Game.ObjectOnSceneMarkers;

namespace Game.Animals.Behaviour.Collisions
{
    public abstract class CollisionReactBase
    {
        public abstract void ReactTo(IInteractableObjectOnScene reactFrom, InteractableObjectOnScene reactTo);
    }
}