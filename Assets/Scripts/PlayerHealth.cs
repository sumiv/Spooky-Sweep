using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public Transform respawnPoint;
    public GameObject player;
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLivesText();
    }

    public void TakeDamage()
    {
        lives--;
        UpdateLivesText();

        if (lives > 0)
        {
            // Respawn player
            player.transform.position = respawnPoint.position;
        }
        else
        {
            // Game over logic
            //Debug.Log("Game Over! Lives depleted.");
            GameManager.instance.LoseGame();
        }
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
        else
        {
            Debug.LogError("LivesText is not assigned in the PlayerHealth script.");
        }
    }
}
