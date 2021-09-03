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

    float enemyHP = 3;
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


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            enemyHP -= 4;

            if (enemyHP <= 0)
            {

                //gameObject.GetComponent<FractureThis>().enabled = true;
                //gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                Destroy(gameObject);

                if (fractureObj)
                {
                    fractureObj.SetActive(true);


                    fractureObj.gameObject.GetComponentInChildren<Rigidbody>().AddExplosionForce(1000, gameObject.transform.position, 100);
                    fractureObj.transform.position = transform.position;


                    //fractureObj.AddComponent<script>();
                }

            }






        }
    }
}
