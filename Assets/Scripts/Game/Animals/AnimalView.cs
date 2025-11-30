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
        
        public abstract void ChangeColor(Color color);

        #region === Unity Events ===

        private void OnCollisionEnter(Collision collision)
        {
            CollisionEntered?.Invoke(collision);
        }

        #endregion === Unity Events ===
        public virtual float GetObjectHeight()
        {
            return bodyCollider.bounds.size.y;
        }

        public virtual void ChangeVelocity(Vector3 velocity)
        {
            rb.linearVelocity = velocity;
        }
    }
}