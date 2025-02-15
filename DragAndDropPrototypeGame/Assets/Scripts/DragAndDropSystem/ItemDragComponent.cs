using Scripts.Components;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.DragAndDromSystem
{
    public class ItemDragComponent : MonoBehaviour, IInteractable
    {
        private Rigidbody2D _rbody;
        private Camera _mainCamera;
        private RaycastComponentChecker<IContainable> slotChecker;
        private Vector2 mousePosition;
        private Vector3 _originScale;
        private Vector3 _changedScale;
        private void Start()
        {
            _rbody = GetComponent<Rigidbody2D>();
            _mainCamera = Camera.main;
            _originScale = transform.localScale;
            slotChecker = new();
        }

        public void OnBeginInteract(Vector2 mousePosition)
        {
            StopObject();
            GravityOff();
            ReturnObjectSize();
        }

        public void OnInteract(Vector2 mousePosition)
        {
            transform.position = mousePosition;
        }

        public void OnEndInteract(Vector2 mousePosition)
        {
            if (slotChecker.ComponentCheck(mousePosition, out var slot))
            {
                var config = slot.GetSlotConfig();
                transform.position = config.SlotPosition;
                DecreaseObjectSize(config.SizeChangeCoefficient);
                GravityOff();

            }
            else
            {
                GravityOn();

            }
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
}

