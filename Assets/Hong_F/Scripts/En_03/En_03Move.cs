using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class En_03Move : MonoBehaviour
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
        
            target = GameObject.Find("Player");
            Vector3 vec = target.transform.position - transform.position;
            vec.Normalize();
            Quaternion q = Quaternion.LookRotation(vec);
            transform.rotation = q;
        

        


    }
}
