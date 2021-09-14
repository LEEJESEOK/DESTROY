using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    NavMeshAgent nav;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        nav = GetComponent<NavMeshAgent>();
        //gameObject.GetComponent<FractureThis>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);
    }
}
