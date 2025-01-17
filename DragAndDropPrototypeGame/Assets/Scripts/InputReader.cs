﻿using System;
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
        //_inputActions.Gameplay.Drag.started += OnDragBegin;
        //_inputActions.Gameplay.Drag.performed += OnDrag;
        _inputActions.Gameplay.Tap.started += OnTapDown;  
        //_inputActions.Gameplay.Tap.canceled += OnTapUp;
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        //_inputActions.Gameplay.Drag.started -= OnDrag;
        //_inputActions.Gameplay.Drag.performed -= OnDrag;
        _inputActions.Gameplay.Tap.started -= OnTapDown;
        //_inputActions.Gameplay.Tap.canceled -= OnTapUp;
        _inputActions.Gameplay.Disable();
    }

    //вызывается только один раз
    private void OnDragBegin(InputAction.CallbackContext context)
    {
        Vector2 screenPosition = context.ReadValue<Vector2>();

        _interactChecker.ComponentCheck(screenPosition, out _interactable);
        Debug.Log($"Up, interactable = {_interactable}");
        _interactable?.OnBeginInteract();
    }
    private void OnDrag(InputAction.CallbackContext context)
    {
        Vector2 screenPosition = context.ReadValue<Vector2>();

        if (_interactable == null)
        {
            Debug.Log("NO DRAG");
            return;
        }
        var position = Camera.main.ScreenToWorldPoint(screenPosition);
        Debug.Log("DRAG");
        _interactable.OnInteract(position);
    }

    private void OnTapUp(InputAction.CallbackContext context)
    {
        _interactable?.OnEndInteract();
        Debug.Log($"End, interactable = {_interactable}");

    }
    private void OnTapDown(InputAction.CallbackContext context)
    {
        Debug.Log("Begin"); 
        if (Touch.activeFingers.Count <= 0)
            return;
        var touch = Touch.activeFingers[0];
        Vector2 screenPosition = touch.screenPosition;

        _interactChecker.ComponentCheck(screenPosition, out _interactable);
        Debug.Log($"Up, interactable = {_interactable}");
        _interactable?.OnBeginInteract();
    }
}

