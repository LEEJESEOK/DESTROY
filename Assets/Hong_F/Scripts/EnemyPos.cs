using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPos : MonoBehaviour
{
    public GameObject EnemyFactory;
    Rigidbody rb;
    float power = 500;

    // Start is called before the first frame update
    void Start()
    {
       
        GameObject Enemy = Instantiate(EnemyFactory);
        Enemy.transform.position = Enemypos.transform.position;

        

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
