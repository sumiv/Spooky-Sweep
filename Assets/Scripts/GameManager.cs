using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalItems = 33;
    private int itemsCollected = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Subscribe to sceneLoaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe when the GameManager is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentScene = scene.name;
        // Destroy GameManager if in "YouWinScene" or "YouLoseScene"
        if (currentScene == "YouWinScene" || currentScene == "YouLoseScene")
        {
            Destroy(gameObject); 
        }
    }

    public void CollectItem()
    {
        itemsCollected++;
        if (itemsCollected >= totalItems)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        SceneManager.LoadScene("YouWinScene");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("YouLoseScene");
    }

    public void ResetState()
    {
        itemsCollected = 0;
        totalItems = 33;
    }
}