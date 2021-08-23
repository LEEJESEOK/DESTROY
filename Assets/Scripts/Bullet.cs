using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float speed { get; set; }
    [HideInInspector]
    public int damage { get; set; }

    Rigidbody rigidbody;

    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        // 적에 명중
        if (other.gameObject.tag.Contains("Enemy"))
        {
            // 명중한 적의 체력 감소
        }
    }
}
