using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_04Move : MonoBehaviour
{

    public GameObject target;
    public float rotspeed = 100f;

    Rigidbody rigidbody;

    Vector3 dir;


    Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position - transform.position;
        transform.LookAt(target.transform);
        axis = transform.right;
        axis.Normalize();

        rigidbody = GetComponent<Rigidbody>();
       
        //이동하는 방향을 바라보게 하고
    }

    // Update is called once per frame
    void Update()
    {
        float rotx;
        // 일단 플레이어가 있는 방향으로 이동할꺼야 
        transform.position += dir * 10 * Time.deltaTime;

        //transform.Rotate(axis, 500*Time.deltaTime);
        rigidbody.AddTorque(axis * 50);

        //Quaternion.Euler(dir * 500 * Time.deltaTime);
        dir.Normalize();

        // 바라본쪽으로 회전


    }
}
