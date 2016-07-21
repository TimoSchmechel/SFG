using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour {

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("");
    }
    public void Credits()
    {
        SceneManager.LoadScene("");
    }
    public void Options()
    {
        SceneManager.LoadScene("");
    }
}
