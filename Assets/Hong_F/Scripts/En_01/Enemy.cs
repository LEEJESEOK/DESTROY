using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed;

    NavMeshAgent nav;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);
    }
}
