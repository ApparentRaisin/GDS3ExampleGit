using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager SceneManagerInstance;

    void Awake()
    {
        SceneManagerInstance = this;
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
