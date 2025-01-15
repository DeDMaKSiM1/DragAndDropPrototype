
using System;
using UnityEngine;

public class RaycastComponentChecker<T> : MonoBehaviour
{
    public static bool ComponentCheck(Vector2 mousePosition, out T slot)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D[] hitArr = Physics2D.RaycastAll(ray.origin, ray.direction);

        try
        {
            foreach (var item in hitArr)
            {
                if (item.collider.TryGetComponent<T>(out slot))
                { 
                    return true;
                } 
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        slot = default;
        return false;
    }
}
