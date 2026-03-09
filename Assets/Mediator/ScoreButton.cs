using UnityEngine;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour
{
    public ScoreManager manager;

    Button thisButton;
    public void SetManager(ScoreManager manager)
    {
        this.manager = manager;
    }

    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(delegate
        { 
            manager.IncreaseScore(1); 
            Destroy(this.gameObject);
        });
    }
}
