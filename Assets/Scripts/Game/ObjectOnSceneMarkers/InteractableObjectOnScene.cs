using UnityEngine;

namespace Game.ObjectOnSceneMarkers
{
    public class InteractableObjectOnScene : MonoBehaviour, IInteractableObjectOnScene
    {
        public Transform Transform => transform;
    }
}