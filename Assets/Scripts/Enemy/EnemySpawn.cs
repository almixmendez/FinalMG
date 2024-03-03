using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    // Spawn de enemigos.
    public GameObject enemy;
    private float positionY = -0.18f;
    private float enemyPositionZ = 3.88f;
    private float enemyPositionX = 11.05f;
    public float spawnInterval = 1.0f;

    // Contador.
    public TextMeshProUGUI TimerText;
    public float initialTime = 60.0f;
    private float timer;

    private void Start()
    {
        timer = initialTime;
        InvokeRepeating("EnemySpawner", 0, spawnInterval);
        InvokeRepeating("UpdateTimer", 1, 1);
    }

    void EnemySpawner()
    {

        float randomX = Random.Range(-enemyPositionX, enemyPositionX);
        Vector3 spawnPosition = new Vector3(randomX, positionY, enemyPositionZ);

        GameObject newEnemy = Instantiate(enemy, spawnPosition, enemy.transform.rotation);
        Destroy(newEnemy, 3.0f);
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateTimer()
    {
        timer -= 1;
        UpdateTimerText();

        if (timer <= 0)
        {
            timer = 0;
        }
    }
}
