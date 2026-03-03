using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Transform thisTransform;

    public float speed;
    InputAction movement;
    InputAction jump;

    void Start()
    {
        thisTransform = this.transform;

        movement = InputSystem.actions.FindAction("Move");

        jump = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        Vector2 move = movement.ReadValue<Vector2>();
        float jumping = jump.ReadValue<float>();
        thisTransform.position += new Vector3(move.x,0,move.y) * speed * Time.deltaTime;

        if(jumping >= 0.5f)
        {
            thisTransform.position += new Vector3(0,1,0) * speed * Time.deltaTime;
        }
        else
        {
            //Do nothing!
        }
    }
}

