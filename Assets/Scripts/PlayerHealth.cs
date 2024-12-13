using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //starting life, starting position
    public int lives = 3;
    public Transform respawnPoint; 
    public GameObject player; 

    public void TakeDamage()
    {
        lives--;
        if (lives > 0)
        {
            // respawn
            player.transform.position = respawnPoint.position;
        }
        else
        {
            // game over!
            //FindObjectOfType<GameManager>().GameOver();
            Debug.Log("Game Over! Lives depleted.");
        }
    }
}
