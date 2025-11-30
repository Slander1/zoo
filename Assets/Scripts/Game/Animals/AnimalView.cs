using System;
using UnityEngine;

namespace Game.Animals
{
    public abstract class AnimalView : MonoBehaviour
    {
        public event Action<Collision> CollisionEntered;

        [SerializeField] private Collider bodyCollider;
        [SerializeField] private MeshFilter filter;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private MeshRenderer meshRenderer;

        #region === Unity Events ===

        private void Awake()
        {
            SetRandomColor();
        }

        private void OnCollisionEnter(Collision collision)
        {
            CollisionEntered?.Invoke(collision);
        }

        #endregion === Unity Events ===
        
        public float GetObjectHeight()
        {
            return bodyCollider.bounds.size.y;
        }

        public void ChangeVelocity(Vector3 velocity)
        {
            rb.linearVelocity = velocity;
        }
        
        public void SetRandomColor()
        {
            var randomColor = new Color(
                UnityEngine.Random.value,
                UnityEngine.Random.value,
                UnityEngine.Random.value
            );

            ChangeColor(randomColor);
        }
        
        private void ChangeColor(Color color)
        {
            meshRenderer.material.color = color;
        }
    }
}