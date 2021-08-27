using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public Transform target;
    public float height;
    public float distance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, height, target.position.z - distance);
        transform.LookAt(target);
    }
}
