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
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.LoseHealth(25);
        }
    }
}
