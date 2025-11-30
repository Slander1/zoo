using Game.Animals;

namespace Game.Providers
{
    public interface IObjectPoolProvider
    {
        public bool TryGetElemFromObjectPool(out AnimalBase animal);
    }
}