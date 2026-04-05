using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NavMeshController : MonoBehaviour
{
    public NavMeshAgent agent;
    InputAction mousePosition;
    Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePosition = InputSystem.actions.FindAction("Point");
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = mousePosition.ReadValue<Vector2>();
        RaycastHit hit;
        if(Physics.Raycast(mainCamera.ScreenPointToRay(mousePos), out hit))
        {
            agent.destination = hit.point;
        }
        
    }
}
