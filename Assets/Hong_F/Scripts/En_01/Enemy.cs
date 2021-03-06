using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
        if (GameManager.instance.gameState != GameManager.GameState.Play)
            return;
            
        nav.SetDestination(player.transform.position);
    }
}
