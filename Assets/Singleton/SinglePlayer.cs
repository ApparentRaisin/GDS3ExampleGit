using UnityEngine;
using UnityEngine.InputSystem;

public class SinglePlayer : MonoBehaviour
{
    Transform thisTransform;

    InputAction move;
    void Start()
    {
        thisTransform = this.transform;
        SceneManager.SceneManagerInstance.SetMainPlayer(thisTransform);
        move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 direction = move.ReadValue<Vector2>();

        thisTransform.position += new Vector3(direction.x,0,direction.y) * Time.deltaTime * 4;
    }
}
