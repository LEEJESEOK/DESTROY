using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_04Move : MonoBehaviour
{

    public GameObject target;
    public float rotspeed = 100f;

    Vector3 dir;


    Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position - transform.position;
        transform.LookAt(target.transform);

        print("dir : " + dir);
        print(transform.forward);
        //�̵��ϴ� ������ �ٶ󺸰� �ϰ�
        axis = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        float rotx;
        // �ϴ� �÷��̾ �ִ� �������� �̵��Ҳ��� 
        transform.position += dir * 10 * Time.deltaTime;

        transform.Rotate(axis, Time.time);


        //Quaternion.Euler(dir * 500 * Time.deltaTime);
        dir.Normalize();

        // �ٶ������� ȸ��


    }
}
