using System;
using UnityEngine;

namespace Game.Animals.Behaviour.Movers.Data
{
    [Serializable]
    public class DataBase : IMoverData
    {
        [SerializeField] private float moveSpeed = 2;
        [SerializeField] private float rotationSpeed = 15;
        
        public AnimalView View { get; private set; }
        public Transform Transform { get; private set; }
        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;

        public void Initialize(AnimalView view, Transform transform)
        {
            View = view;
            Transform = transform;
        }
    }
}