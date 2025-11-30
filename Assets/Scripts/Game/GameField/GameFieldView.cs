using UnityEngine;

namespace Game.GameField
{
    public sealed class GameFieldView : MonoBehaviour
    {
        public MeshCollider MeshCollider => meshCollider;
        
        [SerializeField] private MeshCollider meshCollider;
    }
}