using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text ammoText;
    public int gunAmmo = 10;

    public Text healthText;
    public int health = 100;

    public GameObject victoryPanel;
    public GameObject defeatPanel;

    public WinOrLoose winOrLooseScript;

    private bool gamePaused = false;

    private void Awake()
    {
        Instance = this;
    }

    public void EndGame(bool isVictory)
    {
        if (isVictory)
        {
            victoryPanel.SetActive(true);
        }
        else
        {
            defeatPanel.SetActive(true);
        }
    }

    // Botones.
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gamePaused = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("UI");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();

        if (victoryPanel.activeSelf || defeatPanel.activeSelf)
        {
            PauseGame();
        }
        else if (gamePaused)
        {
            ResumeGame();
        }
    }

    public void LoseHealth(int lessHealth)
    {
        UpdateHealth();
        health -= lessHealth;

        if (health <= 0)
        {
            Debug.Log("memuri");
            EndGame(false); // Llama a EndGame si la salud es menor o igual a cero.
        }
    }

    public void UpdateHealth()
    {
        healthText.text = health.ToString();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }
}
