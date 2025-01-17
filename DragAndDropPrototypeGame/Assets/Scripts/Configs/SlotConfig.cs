
using UnityEngine;

[CreateAssetMenu(fileName = "NewSlotConfig", menuName = "Configs/Slot")]
public class SlotConfig : ScriptableObject
{
    public float SizeChangeCoefficient = 0.8f;
    public Vector3 SlotPosition;
 
}

