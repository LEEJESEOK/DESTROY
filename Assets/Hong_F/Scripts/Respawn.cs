using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider rangeCollider;

    public GameObject Enemy;
    int enemyCount;
    // Start is called before the first frame update
    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

   public   void Start()
    {
        
           StartCoroutine(RandomRespawn_Coroutine());

        
    }

    // Update is called once per frame
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;

        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);

        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
        
    }

    public IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            
                yield return new WaitForSeconds(1f);
                if (enemyCount < 1000)
                { 
                     GameObject instantEnemy = Instantiate(Enemy, Return_RandomPosition(), Quaternion.identity);
                    enemyCount++;
                }

            

        }
    }
}
