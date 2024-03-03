using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinOrLoose : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int requiredEnemies = 15;
    private int enemiesEliminated = 0;
    public TextMeshProUGUI timeText;
    private float timeRemaining;
    private bool gameEnded = false;

    private void Start()
    {
        // Condición.
        enemiesEliminated = 0;
        timeRemaining = 230.0f;
        UpdateCounterText();
        UpdateTimeText();
    }

    private void Update()
    {
        if (!gameEnded)
        {
            timeRemaining -= Time.deltaTime;
            UpdateCounterText();
            UpdateTimeText();

            if (timeRemaining <= 0 && enemiesEliminated < requiredEnemies)
            {
                GameManager.Instance.EndGame(false); // Llama al método EndGame del GameManager con false (derrota).
                gameEnded = true;
            }
        }
    }

    public void EnemyEliminated()
    {
        enemiesEliminated++;
        UpdateCounterText();

        if (enemiesEliminated >= requiredEnemies && timeRemaining > 0)
        {
            GameManager.Instance.EndGame(true); // Llama al método EndGame del GameManager con true (victoria).
            gameEnded = true;
        }
    }

    void UpdateCounterText()
    {
        counterText.text = enemiesEliminated + "/" + requiredEnemies;
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60F);
        int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);
        string timeString = string.Format("{0:0}:{1:00}", minutes, seconds);
        timeText.text = "Time left " + timeString;
    }
}
