
using Scripts.Interfaces;
using UnityEngine;

public class ItemPackHandler : MonoBehaviour 
{
    public void PackIn(Vector2 slotPosition)
    {
        transform.position = slotPosition;
    }
}

