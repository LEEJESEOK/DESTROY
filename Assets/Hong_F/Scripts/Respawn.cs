using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;

    public GameObject[] enemy;
    int enemyCount;
    int idx;
    int rand;
    private System.Random rng = new System.Random();


    // Start is called before the first frame update
    private void Awake()
    {
    }

    public void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    // Update is called once per frame
    Vector3 RandomPosition()
    {
        Vector3 randPosition = Random.insideUnitCircle;
        Vector3 position = new Vector3(randPosition.x, 0, randPosition.y);

        return player.transform.position + position * 30f;
    }

    public IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (enemyCount < 1000)
            {
                rand = rng.Next(100);

                if (rand <= 60)
                {
                    idx = 0;
                }
                else if (61 < rand && rand <= 80)
                {
                    idx = 1;
                }
                else if (81 < rand && rand <= 90)
                {
                    idx = 2;
                }
                else
                {
                    idx = 3;
                }

                GameObject instantEnemy = Instantiate(enemy[idx], RandomPosition(), Quaternion.identity);
                enemyCount++;
            }
        }
    }
}
