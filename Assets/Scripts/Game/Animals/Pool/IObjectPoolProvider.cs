namespace Game.Animals.Pool
{
    public interface IObjectPoolProvider
    {
        public bool TryGetElemFromObjectPool(out AnimalBase animal);
    }
}