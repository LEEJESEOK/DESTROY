using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePos_02 : MonoBehaviour
{

    public GameObject BulletFactory;
    public Transform FirePos;
    float currTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > 1.5f)
        {
            GameObject Bullet = Instantiate(BulletFactory);
            Bullet.transform.forward = FirePos.forward;
            Bullet.transform.position = FirePos.transform.position;

            currTime = 0;
        }

    }
}
