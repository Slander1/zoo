using Game.Animals.Roles;

namespace Game.Animals.StatCounters
{
    public sealed class DiedState
    {
        public int PreyDiedCount;
        public int PredatorDiedCount;

        public void Update(AnimalBase animal)
        {
            if (animal is IPredator) PredatorDiedCount++;
            if (animal is IPray) PreyDiedCount++;
        }
    }
}