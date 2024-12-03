using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
