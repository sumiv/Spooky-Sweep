using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //track total items 
    public int totalItems = 33;
    private int itemsCollected = 0;
    public void Awake()
    {
        // only one GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
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
}
