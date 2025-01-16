using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

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
        _inputActions.Gameplay.Drag.canceled += OnDragEnd;
        _inputActions.Gameplay.Tap.performed += OnTap;
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Gameplay.Drag.performed -= OnDrag;
        //_inputActions.Gameplay.Drag.canceled -= OnDragEnd;
        _inputActions.Gameplay.Tap.performed -= OnTap;

        _inputActions.Gameplay.Disable();
    }
    private void OnDrag(InputAction.CallbackContext context)
    {
        Vector2 position = context.ReadValue<Vector2>();

        if (_interactable == null)
        {
            _interactChecker.ComponentCheck(position, out _interactable);
            Debug.Log("Inter == null");
            return;
        }

        _interactable.OnInteract(position);
    }
    private void OnDragEnd(InputAction.CallbackContext context)
    {
        Debug.Log("END");
        //NOT WORKING!!
        _interactable = null;
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        if (Touch.activeTouches.Count <= 0)
        {
            Debug.LogWarning($"Touch.activeTouches.Count = {Touch.activeTouches.Count}");
            return;

        }
        var touch = Touch.activeTouches[0];
        var mousePosition = touch.screenPosition;
        //В классе ItemDragHandler вызвать метод OnClick, проверять на коллайдер ???????????????????
    } 
}

