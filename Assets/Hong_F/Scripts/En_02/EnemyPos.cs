using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPos : MonoBehaviour
{
    public GameObject[] EnemyFactory = new GameObject[3];
    public GameObject Enemypos;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.RandomRange(0, 100);
        float currTime = Time.deltaTime;

        if(rand < 70)
        {
            GameObject Enemy = Instantiate(EnemyFactory[0]);
            Enemy.transform.position = Enemypos.transform.position;
        }
        else if(71 < rand || rand < 90)
        {
            GameObject Enemy = Instantiate(EnemyFactory[1]);
            Enemy.transform.position = Enemypos.transform.position;
        }

        else if(91 < rand || rand < 100)
        {
            GameObject Enemy = Instantiate(EnemyFactory[2]);
            Enemy.transform.position = Enemypos.transform.position;
        }
       
       

        

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
