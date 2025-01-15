using Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;


public class ItemDragHandler : MonoBehaviour
{
    private Rigidbody2D _rbody;
    private Camera _mainCamera;

    public UnityEvent MouseUp;
    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }
    private void OnMouseDown()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _rbody.gravityScale = 0f;

        transform.position = mousePosition;

        transform.localScale *= 0.8f;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

    }
    private void OnMouseUp()
    {
        transform.localScale /= 0.8f;
        _rbody.angularVelocity = 0;
        _rbody.linearVelocity = Vector2.zero;

        if (CheckForTrigger(out var slot))
        {
            transform.position = slot.GetSlotPosition();
            _rbody.gravityScale = 0f;
        }
        else
            _rbody.gravityScale = 1f;
    }
    public bool CheckForTrigger(out IContainable slot)
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hitArr = Physics2D.RaycastAll(ray.origin, ray.direction);

        foreach (var item in hitArr)
        {
            if (item.collider.TryGetComponent<IContainable>(out slot))
            {
                Debug.Log("Успешно " + slot);
                return true;
            }
        }
        slot = default;
        return false;
    }
}
