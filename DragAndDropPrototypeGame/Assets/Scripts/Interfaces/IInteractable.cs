 
using UnityEngine;

public interface IInteractable
{
    public void OnBeginInteract();
    public void OnInteract(Vector2 mousePosition);
    public void OnEndInteract();
}

