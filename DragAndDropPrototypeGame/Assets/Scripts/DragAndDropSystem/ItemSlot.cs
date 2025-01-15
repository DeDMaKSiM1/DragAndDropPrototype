using Scripts.Interfaces;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IContainable
{
    [SerializeField] private SlotConfig _config;
    [SerializeField] private Transform _slotPosition;

    public SlotConfig GetSlotConfig()
    {
        _config.SlotPosition = _slotPosition.position;

        return _config;
    }
}

