using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z - 8f);
        transform.LookAt(target);
    }
}
