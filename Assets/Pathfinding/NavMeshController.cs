using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class NavMeshController : MonoBehaviour
{
    public NavMeshAgent agent;

    List<NavMeshAgent> agentList = new List<NavMeshAgent>() ;
    InputAction mousePosition;
    Camera mainCamera;

    float nT;

    public int count = 1;

    void Start()
    {
        mousePosition = InputSystem.actions.FindAction("Point");
        mainCamera = Camera.main;
        agentList.Add(agent);

        for(int i = 0; i < 1000; i++)
        {
            forward.Push(Instantiate(agent, Vector3.zero, Quaternion.identity));
        }

        count = 1000;
    }
    
    //Holders for the agents
    Stack<NavMeshAgent> forward = new Stack<NavMeshAgent>(), back = new Stack<NavMeshAgent>();
    void Update()
    {
        Vector2 mousePos = mousePosition.ReadValue<Vector2>();
        RaycastHit hit;

        Physics.Raycast(mainCamera.ScreenPointToRay(mousePos), out hit);

        //Splits the amount of agents calcualtions done per frame in half to decrease distance calc overhead
        //uses two stacks one as back buffer, for ease of swapping in and out
        for(int i = 0; i < count/2; i++)
        {
            if(forward.Count == 0)
            {
                break;
            }

            NavMeshAgent temp = forward.Pop();
            if(Vector3.Distance(temp.transform.position, hit.point) > 2)
            {
                temp.destination = hit.point;
                Debug.Log("Set");
            }
                
            back.Push(temp);
        }

        if(forward.Count == 0)
        {
            forward = new Stack<NavMeshAgent>(back);
            back.Clear();
        }

    }
    
}


