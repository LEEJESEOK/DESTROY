using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;

    public int respawnCount;
    public float respawnDelay;

    public GameObject[] enemyObj;
    List<GameObject> enemyList;
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
        enemyList = new List<GameObject>();
        for (int i = 0; i < respawnCount; i++)
        {
            // rand = rng.Next(enemyObj.Length);
            rand = Random.Range(0, 100);
            GameObject enemy;

            if (rand > 0 && rand <= 60)
            {
                enemy = Instantiate(enemyObj[0]);
            }
            else if (rand >= 61 && rand <= 80)
            {
                enemy = Instantiate(enemyObj[1]);
            }
            else
            {
                enemy = Instantiate(enemyObj[2]);
            }
            enemy.SetActive(false);
            enemyList.Add(enemy);
        }

        StartCoroutine(RandomRespawn_Coroutine());
    }

    // Update is called once per frame
    Vector3 RandomPosition()
    {
        Vector3 randPosition = Random.insideUnitCircle;
        Vector3 position = new Vector3(randPosition.x, 0, randPosition.y);
        position.Normalize();

        return player.transform.position + position * 30f;
    }

    public IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnDelay);

            if (enemyList.Count > 0)
            {
                GameObject enemy = enemyList[0];
                enemy.transform.position = RandomPosition();
                enemy.SetActive(true);

                enemyList.RemoveAt(0);
            }
        }
    }
}
