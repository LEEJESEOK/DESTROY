using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float height;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, height, target.position.z - distance);
        transform.LookAt(target);
    }
}
