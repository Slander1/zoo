using Game.ObjectOnSceneMarkers;
using UnityEngine;

namespace Game.GameField.Builders.Walls
{
    public interface IWall : IInteractableObjectOnScene
    {
        public Vector3 CenterPosition { get; }
    }
}