using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;

public class NavMeshControllerTouch : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] List<NavMeshAgent> agents = new List<NavMeshAgent>();
    InputAction clickAction;
    InputAction mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickAction = InputSystem.actions.FindAction("Click");
        mousePos = InputSystem.actions.FindAction("Point");
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (UnityEngine.InputSystem.EnhancedTouch.Touch toucheEvent in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            if(toucheEvent.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                Vector2 screenPosition = toucheEvent.finger.screenPosition;
                if (clickAction.WasPressedThisFrame())
                {
                    RaycastHit hit;
                    if(Physics.Raycast(cam.ScreenPointToRay(mousePos.ReadValue<Vector2>()), out hit))
                    {
                        foreach(NavMeshAgent agent in agents)
                        {
                            agent.SetDestination(hit.point);
                        }                
                    }
                }
            }
            
        }
    }
}
