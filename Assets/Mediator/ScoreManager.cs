using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int currentScore = 0;
    public void IncreaseScore(int amount)
    {
        currentScore += amount;
    }
    void Update()
    {
        scoreText.text = currentScore.ToString();
    }
}
