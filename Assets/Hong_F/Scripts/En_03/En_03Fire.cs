using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class En_03Fire : MonoBehaviour
{

    public GameObject BulletFactory;
    public Transform FirePos;
    float currTime;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject Player = GameObject.Find("Player");

        float DistanceX = Player.transform.position.x - transform.position.x;
        float DistanceZ = Player.transform.position.z - transform.position.z;
        
        if ((DistanceX <= 15 && DistanceZ <= 15) && (DistanceX > -15 && DistanceZ > -15))
        {
            currTime += Time.deltaTime;
            if (currTime > 1.5f)
            {
                transform.LookAt(Player.transform);
                GameObject Bullet = Instantiate(BulletFactory);
                Bullet.transform.forward = FirePos.forward;
                Bullet.transform.position = FirePos.transform.position;

                currTime = 0;
            }
        }







    }
}
