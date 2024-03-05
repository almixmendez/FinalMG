using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Start()
    {
        int isGamePaused = PlayerPrefs.GetInt("IsGamePaused", 0);
        if (isGamePaused == 1)
        {
            GameManager.Instance.PauseGame();
        }
        else
        {
            GameManager.Instance.UnpauseGame();
        }
    }

    public void PlayGame()
    {
        Debug.Log("Cambio");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
