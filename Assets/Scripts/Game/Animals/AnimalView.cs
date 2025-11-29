using UnityEngine;

namespace Game.Animals
{
    public abstract class AnimalView : MonoBehaviour
    {
        [SerializeField] private Collider bodyCollider;
        [SerializeField] private MeshFilter filter;
        [SerializeField] private Rigidbody rb;
        
        public abstract void ChangeColor(Color color);

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