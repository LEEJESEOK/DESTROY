using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 1;

    new Rigidbody rigidbody;

    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    protected void FixedUpdate()
    {        
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        // 적에 명중
        if (other.gameObject.tag.Contains("Enemy"))
        {

            //TODO 명중한 적의 체력 감소
        }
    }
}