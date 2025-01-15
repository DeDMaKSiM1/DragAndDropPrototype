using Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;


public class ItemDragHandler : MonoBehaviour
{
    private Rigidbody2D _rbody;
    private Camera _mainCamera;
    private Vector2 mousePosition;

    public UnityEvent MouseUp;
    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }
    private void OnMouseDown()
    {
        mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _rbody.gravityScale = 0f;

        transform.position = mousePosition;

        transform.localScale *= 0.8f;
    }

    private void OnMouseDrag()
    {
        mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

    }
    private void OnMouseUp()
    {
        ;
        transform.localScale /= 0.8f;
        _rbody.angularVelocity = 0;
        _rbody.linearVelocity = Vector2.zero;

        if (RaycastComponentChecker<IContainable>.ComponentCheck(Input.mousePosition, out var slot))
        {
            transform.position = slot.GetSlotPosition();
            _rbody.gravityScale = 0f;
        }
        else
            _rbody.gravityScale = 1f;
    }

}
