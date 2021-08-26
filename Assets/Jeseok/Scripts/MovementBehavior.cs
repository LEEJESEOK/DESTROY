using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()
    {
    }

    public void Move(Vector3 dir)
    {
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }
}
