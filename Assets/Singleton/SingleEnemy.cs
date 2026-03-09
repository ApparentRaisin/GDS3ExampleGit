using UnityEngine;

public class SingleEnemy : MonoBehaviour
{
    Transform thisTransform;
    void Start()
    {
        thisTransform = this.transform;
    }

    void Update()
    {
        thisTransform.LookAt(SceneManager.SceneManagerInstance.GetMainPlayerPosition());
        thisTransform.position += this.thisTransform.forward * Time.deltaTime * 3f;
    }
}
