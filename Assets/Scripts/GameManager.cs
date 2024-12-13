using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        // Reload the Title Screen (or Game Over Screen)
        SceneManager.LoadScene("TitleScene"); // Ensure TitleScene exists in your Build Settings
    }
}
