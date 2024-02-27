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

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();
    }

    public void LoseHealth(int lessHealth)
    {
        health -= lessHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (health <= 0)
        {
            Debug.Log("memuri");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
