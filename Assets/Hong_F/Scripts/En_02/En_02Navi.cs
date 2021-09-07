using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class En_02Navi : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");

        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.transform.position);

    }
}
