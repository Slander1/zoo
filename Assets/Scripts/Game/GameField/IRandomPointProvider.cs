using UnityEngine;

namespace Game.GameField
{
    public delegate Vector3 GetRandomPointOnField();

    public interface IRandomPointProvider
    {
        public GetRandomPointOnField GetRandomPointOnField { get; }
    }
}