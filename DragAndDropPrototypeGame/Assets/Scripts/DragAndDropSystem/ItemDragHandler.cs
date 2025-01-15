using Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;


public class ItemDragHandler : MonoBehaviour
{
    [SerializeField] private float _sizeChangeCoefficient = 0.8f;
    private Rigidbody2D _rbody;
    private Camera _mainCamera;
    private Vector2 mousePosition;

    private Vector3 _originScale;
    private Vector3 _changedScale; 

     
    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
        _originScale = transform.localScale;
        _changedScale = transform.localScale * _sizeChangeCoefficient;
    }
    private void OnMouseDown()
    {
         mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _rbody.gravityScale = 0f;

        transform.localScale = _originScale;
        transform.position = mousePosition;         
    }

    private void OnMouseDrag()
    {
         mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
    private void OnMouseUp()
    { 
        
        _rbody.angularVelocity = 0;
        _rbody.linearVelocity = Vector2.zero;

        if (RaycastComponentChecker<IContainable>.ComponentCheck(Input.mousePosition, out var slot))
        {
            transform.position = slot.GetSlotPosition();
            _rbody.gravityScale = 0f;
            transform.localScale = _changedScale;
        }
        else
        {
            _rbody.gravityScale = 1f;
        }
    }

}
