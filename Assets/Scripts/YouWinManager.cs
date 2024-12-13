using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinManager : MonoBehaviour
{
    public void ReturnToTitleScreen()
    {
        // Reset the game state and load the title screen
        GameManager.instance.LoadTitleScreen(); 
    }
}
