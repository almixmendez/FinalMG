using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocity = 10.0f;
    public Camera firstPersonCamera;
    public GameObject Projectile;
    public Image sight;
    public Animator animator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Movimiento del player.
        float forwardMovement = Input.GetAxis("Vertical") * velocity;
        float horizontalMovement = Input.GetAxis("Horizontal") * velocity;
        // Animaciones.
        animator.SetFloat("VelX", horizontalMovement);
        animator.SetFloat("VelZ", forwardMovement);


        forwardMovement *= Time.deltaTime;
        horizontalMovement *= Time.deltaTime;

        transform.Translate(horizontalMovement, 0, forwardMovement); //Movimiento en X,Y,Z.

        // Deslockear el cursor del mouse.
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // Raycasting.
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.gunAmmo > 0)
        {
            Ray ray = firstPersonCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            // Checkeo.
            if ((Physics.Raycast(ray, out hit) == true) && hit.distance < 5)
            {
                Debug.Log("El rayo tocó al objeto: " + hit.collider.name);
                sight.color = Color.white;

                //Se invoca al script BotControl, y devuelve el Raycasting.
                if (hit.collider.name.Substring(0, 3) == "Enemy")
                {
                    GameObject hittedObject = GameObject.Find(hit.transform.name);
                    EnemyControl hittedObjectScript = (EnemyControl)hittedObject.GetComponent(typeof(EnemyControl));

                    sight.color = Color.red;

                    if (hittedObjectScript != null)
                    {
                        hittedObjectScript.receiveDamage();
                    }
                }
            }

            //Disparo de proyectiles.
            GameManager.Instance.gunAmmo--;

            GameObject pro;
            pro = Instantiate(Projectile, ray.origin, transform.rotation);

            Rigidbody rb = pro.GetComponent<Rigidbody>();
            rb.AddForce(firstPersonCamera.transform.forward * 15, ForceMode.Impulse);

            Destroy(pro, 5);
        }
    }
}
