using Scripts.Configs;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.DragAndDromSystem
{
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
}


