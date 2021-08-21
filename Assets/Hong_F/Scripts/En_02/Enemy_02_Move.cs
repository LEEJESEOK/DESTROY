using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02_Move : MonoBehaviour
{
    GameObject bin;
    Vector3 dir;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bin = GameObject.Find("En_02");
        dir = Vector3.up;
        dir = bin.transform.position - transform.position;
    }
}
