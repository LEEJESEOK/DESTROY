using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Project.Scripts.Fractures;

public class Enemy : MonoBehaviour
{


    public Transform Target;
    NavMeshAgent nav;
    GameObject player;
    // Start is called before the first frame update

    int enemyHP = 3;
    GameObject fractureObj;
    void Start()
    {
        player = GameObject.Find("Player");

        nav = GetComponent<NavMeshAgent>();
        //gameObject.GetComponent<FractureThis>().enabled = false;
        fractureObj = FractureThis.GetInstance().CreateFracture(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);

        DestoryEn_01();

    }

    public void DestoryEn_01()
    {
        if (enemyHP <= 0)
        {
            //gameObject.GetComponent<FractureThis>().enabled = true;
            //gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            Destroy(gameObject);
            fractureObj.SetActive(true);

            //fractureObj.transform.position = transform.position;

        }
    }
}
