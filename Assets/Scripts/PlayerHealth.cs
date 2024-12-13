using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3; // Starting lives
    public Transform respawnPoint; // Set this to the starting position of the player
    public GameObject player; // Assign the player GameObject

    public void TakeDamage()
    {
        lives--;
        if (lives > 0)
        {
            // Respawn player
            player.transform.position = respawnPoint.position;
        }
        else
        {
            // Trigger Game Over
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
