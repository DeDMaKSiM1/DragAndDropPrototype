using UnityEngine;

public class DragHandler : MonoBehaviour
{
    private Rigidbody2D _rbody;
    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        Debug.Log("Захватили");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        transform.localScale *= 0.8f;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition ;

    }
    private void OnMouseUp()
    {
        Debug.Log("Отпустили");
        transform.localScale /= 0.8f;

        _rbody.angularVelocity = 0;
        _rbody.linearVelocity = Vector2.zero;
    }
}
