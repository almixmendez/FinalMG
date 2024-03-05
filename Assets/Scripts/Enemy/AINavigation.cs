using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public bool followPlayer;
    private GameObject player;

    private float distanceFromPlayer;
    public float distanceToFollowPlayer = 10;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
