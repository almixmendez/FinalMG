using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private int healthPoints;
    private WinOrLoose condition;

    private void Start()
    {
        healthPoints = 100;
        condition = FindObjectOfType<WinOrLoose>();
    }

    // Función de daño.
    public void receiveDamage()
    {
        healthPoints = healthPoints - 50;

        if (healthPoints <= 0)
        {
            this.botDeath();
        }
    }

    public void botDeath()
    {
        Destroy(gameObject);

        condition.EnemyEliminated();
    }

    // Daño por colisión del proyectil.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            receiveDamage();
        }
    }
}
