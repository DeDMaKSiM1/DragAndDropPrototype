using Scripts.Interfaces;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IContainable
{
    [SerializeField] private Transform _slotPosition;

    public Vector2 GetSlotPosition()
    {
        return _slotPosition.position;
    }
}

