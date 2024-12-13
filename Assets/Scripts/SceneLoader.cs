using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
