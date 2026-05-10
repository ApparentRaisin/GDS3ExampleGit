using UnityEngine;

public class Testing : MonoBehaviour
{
    public Vector3 start,end, mid;

    public float delta;

    public AnimationCurve curve;

    public int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    Vector3 c;
    // Update is called once per frame
    void Update()
    {
        //delta = (delta + Time.deltaTime) % 2f;
        //c = Vector3.LerpUnclamped(start,end, curve.Evaluate(delta));
        Debug.Log(c);
    }

    void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(c, 0.5f);

        for(int i =0; i < count-1; i++)
        {
            float cDelt = (float)i/count;

            Vector3 currentStart = Vector3.Lerp(Vector3.Lerp(start,mid, cDelt), Vector3.Lerp(mid,end,cDelt),cDelt);

            cDelt = (float)(i+1)/count;
            Vector3 currentEnd = Vector3.Lerp(Vector3.Lerp(start,mid, cDelt), Vector3.Lerp(mid,end,cDelt),cDelt);
            Gizmos.DrawLine(currentStart,currentEnd);
        }
    }
}
