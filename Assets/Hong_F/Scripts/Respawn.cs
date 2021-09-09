using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject rangeObject;

    GameObject player;

    public GameObject[] Enemy;
    int enemyCount;
    // Start is called before the first frame update
    private void Awake()
    {
        // rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    public void Start()
    {


        player = GameObject.Find("Player");
        StartCoroutine(RandomRespawn_Coroutine());


    }

    // Update is called once per frame
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;

        // float range_X = rangeCollider.bounds.size.x;
        //   float range_Z = rangeCollider.bounds.size.z;
        float range_X = player.transform.position.x;
        float range_Z = player.transform.position.z;

        
        //   range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        //   range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        range_X = Random.Range(((range_X + 100) / 2) * -1, (range_X + 100) / 2);
        range_Z = Random.Range(((range_Z + 100) / 2) * -1, (range_Z + 100) / 2);

       


        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;

    }

    public IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {

            yield return new WaitForSeconds(0.2f);
            if (enemyCount < 1000)
            {
                int rand = Random.Range(0, 100);
                int idx;
                if (rand < 60)
                {
                    idx = 0;
                }

                else if (61 < rand && rand < 80)
                {
                    idx = 1;
                }

                else if (81 < rand && rand < 90)
                {
                    idx = 2;
                }

                else
                {
                    idx = 3;
                }


                GameObject instantEnemy = Instantiate(Enemy[idx], Return_RandomPosition(), Quaternion.identity);
                enemyCount++;
            }



        }
    }
}
