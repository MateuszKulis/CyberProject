using UnityEngine;

namespace WTCProject.Interaction
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        public bool isInteractable;
        public bool isHoldInteract;
        public float holdDuration;

        public bool IsInteractable => isInteractable;
        public bool IsHoldInteract => isHoldInteract;
        public float HoldDuration => holdDuration;

        public virtual void OnInteract()
        {
            Debug.Log("It works!");
        }
    }

}
