using Game.Animals.Behaviour.Collisions.Controllers;

namespace Game.Animals.StateInterfaces
{
    public interface IHaveCollisionController
    {
        public ICollisionController CollisionController { get; }
    }
}