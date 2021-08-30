using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 5f;
    new Rigidbody rigidbody;
    Vector3 speed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime);
    }


    public void Move(Vector3 dir)
    {
        speed = dir * moveForce;
    }
}
