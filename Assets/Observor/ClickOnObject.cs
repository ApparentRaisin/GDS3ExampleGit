using UnityEngine;
using System;
public class ClickOnObject : MonoBehaviour
{

    void Start()
    {
        InputController.OnClickEvent += ClickOn;
    }

    void ClickOn(object sender, InputController.ClickOnArgs eventArgs)
    {
        if(eventArgs.clickedOnObject == this.gameObject)
        {
            Debug.Log("ME");
            this.transform.position = new Vector3(UnityEngine.Random.Range(-4,4),UnityEngine.Random.Range(-4,4),0);
        }
    }
}
