using UnityEngine;

public class SceneManagerDontDestroy : MonoBehaviour
{
    public static SceneManagerDontDestroy SceneManagerInstance;

    void Awake()
    {
        if(SceneManagerInstance == null)
        {
            SceneManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    Transform mainPlayer;

    public void SetMainPlayer(Transform player)
    {
        mainPlayer = player;
    }

    public Vector3 GetMainPlayerPosition()
    {
        return mainPlayer.position;
    }
}
