using Scripts.Interfaces;
using UnityEngine;


public class ItemDragHandler : MonoBehaviour, IInteractable
{
    private Rigidbody2D _rbody;
    private Camera _mainCamera;
    private Vector2 mousePosition;

    private Vector3 _originScale;
    private Vector3 _changedScale;

    RaycastComponentChecker<Collider2D> colliderChecker;
    RaycastComponentChecker<IContainable> slotChecker;
    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
        _originScale = transform.localScale;
        colliderChecker = new();
    }
    public void OnInteract(Vector2 mousePosition)
    {
        Debug.Log($"ТЯНЕТ {gameObject.name} {mousePosition}");
    }
    private void OnMouseDown()
    {
        if (colliderChecker.ComponentCheck(Input.mousePosition, out var component))
        {
            Debug.Log($"Нашелся коллайдер = {component.name}");
        }
        //GravityOff();
        //IncreaseObjectSize();
    }

    //private void OnMouseDrag()
    //{ 
    //    transform.position = GetMousePosition();
    //}
    //private void OnMouseUp()
    //{
    //    _rbody.angularVelocity = 0;
    //    _rbody.linearVelocity = Vector2.zero;

    //    var componentChecker = new RaycastComponentChecker<IContainable>();

    //    if (componentChecker.ComponentCheck(Input.mousePosition, out var slot))
    //    {
    //        var slotConfig = slot.GetSlotConfig();
    //        transform.position = slotConfig.SlotPosition;
    //        GravityOff();
    //        DecreaseObjectSize(slotConfig.SizeChangeCoefficient);

    //    }
    //    else
    //    {
    //        GravityOn();
    //    }
    //}
    private void IncreaseObjectSize()
    {
        transform.localScale = _originScale;
        transform.position = mousePosition;
    }
    private void DecreaseObjectSize(float coefficient)
    {
        _changedScale = transform.localScale * coefficient;
        transform.localScale = _changedScale;
    }
    private void GravityOff()
    {
        _rbody.gravityScale = 0f;
    }
    private void GravityOn()
    {
        _rbody.gravityScale = 1f;
    }

    private Vector2 GetMousePosition() => _mainCamera.ScreenToWorldPoint(Input.mousePosition);

}
