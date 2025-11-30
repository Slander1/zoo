using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Movers.Data
{
    [Serializable]
    public sealed class JumpMoverData : DataBase
    {
        [SerializeField] private float jumpIntervalSeconds;
        [SerializeField] private float  jumpDurationSeconds;
        [SerializeField] private float  jumpHeight;
        
        public float JumpIntervalSeconds => jumpIntervalSeconds;
        public float JumpDurationSeconds => jumpDurationSeconds;
        public float JumpHeight => jumpHeight;
    }
}