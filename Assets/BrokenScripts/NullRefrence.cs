using UnityEngine;

public class NullRefrence : MonoBehaviour
{

    Rigidbody thisRigid;
    Transform respawnPoint;
    void Start()
    {
        thisRigid = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(thisRigid.position.y < -10)
        {
            thisRigid.position = respawnPoint.position;
            thisRigid.linearVelocity = Vector3.zero;
        }
    }


}
