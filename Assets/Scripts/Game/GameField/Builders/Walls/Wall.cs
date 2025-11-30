using Game.ObjectOnSceneMarkers;
using UnityEngine;

namespace Game.GameField.Builders.Walls
{
    public sealed class Wall : InteractableObjectOnScene, IWall
    {
        public Vector3 CenterPosition => transform.position;
    }
}