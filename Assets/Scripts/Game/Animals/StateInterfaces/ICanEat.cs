using Game.Animals.Roles;

namespace Game.Animals.StateInterfaces
{
    public interface ICanEat
    {
        public void Eat(IPray pray);
    }
}