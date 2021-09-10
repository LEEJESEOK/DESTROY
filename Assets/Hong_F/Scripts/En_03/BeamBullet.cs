using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBullet : MonoBehaviour
{
    Vector3 dest;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, dest, 10 * Time.deltaTime);
    }

    public void SetDest(Vector3 dest)
    {
        this.dest = dest;
    }
}
