using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPos : MonoBehaviour
{
    public GameObject[] EnemyFactory = new GameObject[3];
    public GameObject Enemypos;
    float currTime;

    // Start is called before the first frame update
    void Start()
    {
       
            int rand = Random.Range(0, 100);

            if (rand < 60)
            {
                GameObject Enemy = Instantiate(EnemyFactory[0]);
                Enemy.transform.position = Enemypos.transform.position;
            }

            else if (61 < rand && rand < 80)
            {
                GameObject Enemy = Instantiate(EnemyFactory[1]);
                Enemy.transform.position = Enemypos.transform.position;
            }

            else if (81 < rand && rand < 90)
            {
                GameObject Enemy = Instantiate(EnemyFactory[2]);
                Enemy.transform.position = Enemypos.transform.position;
            }

        else if (91 < rand && rand < 100)
        {
            GameObject Enemy = Instantiate(EnemyFactory[3]);
            Enemy.transform.position = Enemypos.transform.position;
        }







    }

    // Update is called once per frame
    void Update()
    {

    }
}
