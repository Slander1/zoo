using UnityEngine;

namespace Game.Providers
{
    public delegate Vector3 GetRandomPointOnField();

    public interface IRandomPointProvider
    {
        public GetRandomPointOnField GetRandomPointOnField { get; }
    }
}