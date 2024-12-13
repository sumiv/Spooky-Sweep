using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the ScoreManager script.");
        }
    }

    public void ResetScore()
    {
        score = 0;
        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
    }

    public int GetScore()
    {
        return score;
    }
}
