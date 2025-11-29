using UnityEngine;

namespace Game.GameField
{
    public sealed class GameFieldView : MonoBehaviour
    {
        // public Bounds ColliderBounds => meshCollider.bounds;
        public MeshCollider MeshCollider => meshCollider;
        
        [SerializeField] private MeshCollider meshCollider;
    }
}