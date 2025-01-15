using Scripts.Interfaces;
using UnityEngine; 


public class ItemDragHandler : MonoBehaviour
{
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
        //_changedScale = transform.localScale * _sizeChangeCoefficient;
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
            var slotConfig = slot.GetSlotConfig();
            transform.position = slotConfig.SlotPosition;
            _changedScale = transform.localScale * slotConfig.SizeChangeCoefficient;
            _rbody.gravityScale = 0f;
            transform.localScale = _changedScale;
        }
        else
        {
            _rbody.gravityScale = 1f;
        }
    }

}
