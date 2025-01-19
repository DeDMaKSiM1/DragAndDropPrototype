using Scripts.Components;
using Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Scripts.DragAndDromSystem
{
    public class InputReader : MonoBehaviour
    {
        private GameplayInput _inputActions;
        private IInteractable _interactable;
        private RaycastComponentChecker<IInteractable> _interactChecker;

        private void Awake()
        {
            _inputActions = new GameplayInput();
            _interactChecker = new();
        }

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            _inputActions.Gameplay.Drag.performed += OnDrag;
            _inputActions.Gameplay.TapPosition.started += OnTapDown;
            _inputActions.Gameplay.TapPosition.canceled += OnTapUp;
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Gameplay.Drag.performed -= OnDrag;
            _inputActions.Gameplay.TapPosition.started -= OnTapDown;
            _inputActions.Gameplay.TapPosition.canceled -= OnTapUp;
            _inputActions.Gameplay.Disable();
        }

        private void OnDrag(InputAction.CallbackContext context)
        {
            if (_interactable == null)
                return;

            Vector2 screenPosition = context.ReadValue<Vector2>();
            var position = Camera.main.ScreenToWorldPoint(screenPosition);

            _interactable.OnInteract(position);
        }

        private void OnTapUp(InputAction.CallbackContext context)
        {
            if (Touch.activeFingers.Count <= 0)
                return;
            var touch = Touch.activeFingers[0];
            Vector2 screenPosition = touch.screenPosition;

            _interactable?.OnEndInteract(screenPosition);
            _interactable = null;

        }

        private void OnTapDown(InputAction.CallbackContext context)
        {
            if (Touch.activeFingers.Count <= 0)
                return;
            var touch = Touch.activeFingers[0];

            _interactChecker.ComponentCheck(touch.screenPosition, out _interactable);
            var position = Camera.main.ScreenToWorldPoint(touch.screenPosition);

            _interactable?.OnBeginInteract(position);
        }
    }
}


