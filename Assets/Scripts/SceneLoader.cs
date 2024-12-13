using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    // title screen linked to scenemanager GO
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void ResetGame()
    {
        // Reset the static GameManager state
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetState();
        }

        // Reset other game-related managers
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }
    }
}
