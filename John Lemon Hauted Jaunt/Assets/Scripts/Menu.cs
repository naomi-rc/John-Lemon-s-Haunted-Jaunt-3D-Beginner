using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();

    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
