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

    public void OnBeginInteract()
    {
        StopObject();
        GravityOff();
        ReturnObjectSize();
    }
    public void OnInteract(Vector2 mousePosition)
    {
        transform.position = mousePosition;
    }
    public void OnEndInteract()
    {
        GravityOn(); 
    }

    private void ReturnObjectSize()
    {
        transform.localScale = _originScale; 
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
    private void StopObject()
    {
        _rbody.linearVelocity = Vector2.zero;
        _rbody.angularVelocity = 0f;
    }

}
