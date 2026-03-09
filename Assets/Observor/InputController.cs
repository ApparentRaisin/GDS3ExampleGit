using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputController : MonoBehaviour
{
    InputAction mouseClick, mousePosition;

    public static event EventHandler<ClickOnArgs> OnClickEvent, OnRleaseEvent;

    
    public class ClickOnArgs : EventArgs{
        public GameObject clickedOnObject = null;
    }

    void Start()
    {
        mouseClick = InputSystem.actions.FindAction("Click");
        mousePosition = InputSystem.actions.FindAction("Point");

        mouseClick.performed += OnClick;
    }

    void OnClick(InputAction.CallbackContext context)
    {
        if (mouseClick.WasReleasedThisFrame())
        {
            OnRleaseEvent?.Invoke(this, new ClickOnArgs());
        }
        else
        {
            RaycastHit hit;

            ClickOnArgs clickArgs = new ClickOnArgs();

            if(Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition.ReadValue<Vector2>()), out hit))
            {
                clickArgs.clickedOnObject = hit.collider.gameObject;
            }
            
            OnClickEvent?.Invoke(this, clickArgs);
        }
    }
}
