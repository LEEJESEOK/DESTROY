using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Fractures;


public class EnmeyFracture : MonoBehaviour
{
    float enemyHP = 3;
    GameObject fractureObj;
    // Start is called before the first frame update
    void Start()
    {
        fractureObj = FractureThis.GetInstance().CreateFracture(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
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

                    Destroy(fractureObj, 4);


                    //fractureObj.AddComponent<script>();
                }

            }






        }
    }
}
