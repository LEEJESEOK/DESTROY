using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    GameObject target;

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
            rand = rng.Next(enemyObj.Length);
            GameObject enemy = Instantiate(enemyObj[rand]);
            enemy.SetActive(false);
            enemyList.Add(enemy);
        }

        target = GameObject.Find("Player");

        StartCoroutine(RandomRespawn_Coroutine());
    }

    // Update is called once per frame
    Vector3 RandomPosition()
    {
        Vector3 randPosition = Random.insideUnitCircle;
        Vector3 position = new Vector3(randPosition.x, 0, randPosition.y);
        position.Normalize();

        return target.transform.position + position * 30f;
    }

    public IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

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
