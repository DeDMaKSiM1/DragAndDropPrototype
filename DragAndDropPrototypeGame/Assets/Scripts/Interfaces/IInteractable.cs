using UnityEngine;

namespace Scripts.Interfaces
{
    public interface IInteractable
    {
        public void OnBeginInteract(Vector2 mousePosition);
        public void OnInteract(Vector2 mousePosition);
        public void OnEndInteract(Vector2 mousePosition);
    }
}


