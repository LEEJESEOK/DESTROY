using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_04Move : MonoBehaviour
{

    public GameObject target;
    public float rotspeed = 100f;

    new Rigidbody rigidbody;

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
       
        //�̵��ϴ� ������ �ٶ󺸰� �ϰ�
    }

    // Update is called once per frame
    void Update()
    {
        // �ϴ� �÷��̾ �ִ� �������� �̵��Ҳ��� 
        transform.position += dir * 10 * Time.deltaTime;

        //transform.Rotate(axis, 500*Time.deltaTime);
        rigidbody.AddTorque(axis * 50);

        //Quaternion.Euler(dir * 500 * Time.deltaTime);
        dir.Normalize();

        // �ٶ������� ȸ��
    }
}
