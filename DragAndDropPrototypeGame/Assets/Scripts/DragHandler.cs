using UnityEngine;

public class DragHandler : MonoBehaviour
{ 
 
    private void OnMouseDown()
    {
        Debug.Log("���������");
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

    }
    private void OnMouseUp()
    {
        Debug.Log("���������");
    }
}
