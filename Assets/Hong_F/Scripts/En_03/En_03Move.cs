using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_03Move : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");
        Vector3 vec = target.transform.position - transform.position;
        vec.Normalize();
        Quaternion q = Quaternion.LookRotation(vec);
        transform.rotation = q;


    }
}
