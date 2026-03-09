using UnityEngine;

public class BirdInstance : MonoBehaviour
{
    Vector3 AimPosition;

    void Start()
    {
        AimPosition = this.transform.position;
    }

    public void SetNewPosition(Vector3 newPostion)
    {
        AimPosition = newPostion;
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, AimPosition, Time.deltaTime * 3);
        if(Vector3.Distance(this.transform.position, AimPosition) < 0.1f)
        {
            this.transform.parent.BroadcastMessage("GetNewPosition", this);
        }
    }
}
