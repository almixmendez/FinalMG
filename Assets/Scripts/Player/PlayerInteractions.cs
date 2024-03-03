using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            Debug.Log("Toqué la caja!");
            Destroy(other.gameObject);
        }

        //if (other.gameObject.CompareTag("DeathFloor"))
        //{
        //    gameObject.transform.position = spawnPoint.position;
        //    GameManager.Instance.LoseHealth(50);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("EnemyBullet"))
        //{
        //    GameManager.Instance.LoseHealth(15);
        //}

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Resta 25 puntos de vida al jugador.
            GameManager.Instance.LoseHealth(25);
        }
    }
}
