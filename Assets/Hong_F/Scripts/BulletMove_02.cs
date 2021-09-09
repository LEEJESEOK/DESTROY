using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove_02 : MonoBehaviour
{
    public int speed = 4;
    // Start is called before the first frame update
    void Start()
    {

        //TODO 불릿 최적화

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
