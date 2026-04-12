using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public int score;
    public string playerName;

    public Transform trans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trans.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
