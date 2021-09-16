using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 5f;
    [SerializeField]
    private float rotateSpeed = 2f;

    Rigidbody rigidbody;
    Vector3 velocity;

    public GameObject aim;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.instance.gameState != GameManager.GameState.Play)
            return;
            
        Vector3 dir = (aim.transform.position - transform.position);
        dir.y = 0;
        Quaternion qDir = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, rotateSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);
    }

    public void Move(Vector3 dir)
    {
        velocity = dir * moveForce;
    }
}
