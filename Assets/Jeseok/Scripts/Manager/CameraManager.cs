using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public Transform target;
    public float height;
    public float distance;

    public float trackingSpeed = 1f;


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
        // 카메라 위치
        transform.position = new Vector3(target.position.x, height, target.position.z - distance);

        // target 방향 회전
        // Vector3 dir = (target.transform.position - transform.position);
        // dir.Normalize();
        // transform.forward = Vector3.Lerp(transform.forward, dir, trackingSpeed * Time.deltaTime);

        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), trackingSpeed * Time.deltaTime);
    }
}
