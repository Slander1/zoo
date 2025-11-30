using UnityEngine;

namespace Game.Animals.Behaviour.Movers.Data
{
    public interface IMoverData
    {
        public AnimalView View { get; }
        public Transform Transform { get; }
        public float MoveSpeed { get; }

        public void Initialize(AnimalView view, Transform transform);
    }
}