using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromPray
{
    [Serializable]
    public class RedirectFromPrayData
    {
        [SerializeField] private float pushStrength = 1f;

        public float PushStrength => pushStrength;
        public Action<Vector3, float> OnRepulsed;
        
        public void Initialize(Action<Vector3, float> onRepulsed)
        {
            OnRepulsed = onRepulsed;
        }
        
    }
}