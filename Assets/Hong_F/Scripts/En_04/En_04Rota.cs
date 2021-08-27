using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_04Rota : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward * 500 * Time.deltaTime);
    }
}
