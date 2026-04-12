using UnityEngine;

public class GizmosExample : MonoBehaviour
{
    GameObject[,] board = new GameObject[8,8];
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                Gizmos.DrawWireCube(new Vector3(x,y,0), Vector3.one);
            }
        }
    }
}
