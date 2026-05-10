using UnityEngine;

public class Maths : MonoBehaviour
{
    public Vector3 VectorDir, refDir;

    public int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {   
        
        
        Gizmos.DrawLine(Vector3.zero, refDir);

        float dot = Vector3.Dot(VectorDir, refDir);
        
        if(dot > 0.5)
        {
            Gizmos.color = Color.white;
        }
        else if(dot < 0.5 && dot > -0.5)
        {
            Gizmos.color = Color.red;
        }
        else if(dot < -0.5)
        {
            Gizmos.color = Color.black;
        }
        

        Gizmos.DrawLine(Vector3.zero, VectorDir);
        
    }

}
