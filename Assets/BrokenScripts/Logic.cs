using UnityEngine;

public class Logic : MonoBehaviour
{
    public GameObject[] objectsToCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(CheckIfAllExist(objectsToCheck));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckIfAllExist(GameObject[] objects)
    {
        bool doExist = true;
        for(int i = 0; i <= objects.Length; i++)
        {
            if(objects[i] == null)
            {
                doExist = false;
            }
        }

        return doExist;
    }
}
