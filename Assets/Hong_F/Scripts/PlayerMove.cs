using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dirh = Vector3.right * h;
        Vector3 dirv = Vector3.forward * v;

        Vector3 dir = dirh + dirv;

        transform.position += dir * 10 * Time.deltaTime;
    }
}
