using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;
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

        //_inputActions.Gameplay.Drag.performed += OnDrag;  
        _inputActions.Gameplay.Tap.canceled += OnTapDown;
        _inputActions.Enable();
    }



    private void OnDisable()
    {
        //_inputActions.Gameplay.Drag.performed -= OnDrag;  
        _inputActions.Gameplay.Tap.canceled -= OnTapDown;

        _inputActions.Gameplay.Disable();
    }
    private void OnDrag(InputAction.CallbackContext context)
    {
        Vector2 position = context.ReadValue<Vector2>();

        if (_interactable == null)
        {
            _interactChecker.ComponentCheck(position, out _interactable);
            Debug.Log($"OnDrag _interactable = {_interactable}");

            return;
        }

        _interactable.OnInteract(position);
    }

    private void OnTapDown(InputAction.CallbackContext context)
    {
        _interactable = null;

        Debug.Log($"END _interactable = {_interactable}");
        //NOT WORKING!!
    }
}

