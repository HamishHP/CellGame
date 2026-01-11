using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int score = 0;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        SetScoreText();
    }

    public void IncrementScore()
    {
        score++;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}