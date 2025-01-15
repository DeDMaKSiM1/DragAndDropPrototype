
using System;
using UnityEngine;

public class RaycastComponentChecker<T>
{ 
    public bool ComponentCheck(Vector2 mousePosition, out T slot)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D[] hitArr = Physics2D.RaycastAll(ray.origin, ray.direction);

        foreach (var item in hitArr)
        {
            if (item.collider.TryGetComponent<T>(out slot))
            {
                return true;
            }
        }
        slot = default;
        return false;
    }
}
