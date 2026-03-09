using UnityEngine;

public class CollectorManager : MonoBehaviour
{
    public ScoreManager currentScoreManager;
    public ScoreButton buttonToSpawn;
    public Canvas mainCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    float nextTick = 0;
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextTick)
        {
            nextTick = Time.time + 1f;
            ScoreButton temp = Instantiate(buttonToSpawn, mainCanvas.transform) as ScoreButton;
            temp.SetManager(currentScoreManager);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-200f,200f),Random.Range(-200f,200f));
        }
    }
}
