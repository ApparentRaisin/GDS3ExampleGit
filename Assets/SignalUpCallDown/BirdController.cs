using UnityEngine;

public class BirdController : MonoBehaviour
{
    public BirdInstance instanceToSpawn;
    void Start()
    {
        
    }

    float nextTick = 0;
    void Update()
    {
        if(Time.time > nextTick)
        {
            nextTick = Time.time + 2;
            Instantiate(instanceToSpawn, this.transform);
        }
    }

    public void GetNewPosition(BirdInstance instance)
    {
        instance.SetNewPosition(Random.insideUnitSphere * 5);
    }
}
