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

    //Collect touches and send to agents as destinations
    //Have to use Enhanced touch here - the for loop collects touches that can then beused for agent events
    //This should be its own function but I wanted to just get this working for now
    void Update()
    {
        //need to work out a way to clean this up
        foreach (UnityEngine.InputSystem.EnhancedTouch.Touch toucheEvent in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            if(toucheEvent.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                Vector2 screenPosition = toucheEvent.finger.screenPosition;
                if (toucheEvent.phase == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    //Not using Camera.main because of caching and wanted to account for multiple cameras
                    RaycastHit hit;
                    if(Physics.Raycast(cam.ScreenPointToRay(screenPosition), out hit))
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
