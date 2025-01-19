 using UnityEngine;

namespace Scripts.Components
{
    public class RaycastComponentChecker<T>
    {
        public bool ComponentCheck(Vector2 mousePosition, out T component)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit2D[] hitArr = Physics2D.RaycastAll(ray.origin, ray.direction);

            foreach (var item in hitArr)
            {
                if (item.collider.TryGetComponent<T>(out component))
                {
                    return true;
                }
            }
            component = default;
            return false;
        }
    }
}

