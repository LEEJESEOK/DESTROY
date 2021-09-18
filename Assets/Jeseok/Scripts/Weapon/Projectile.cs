using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    // 투사체 이동 속도
    public float speed = 3f;
    public int damage = 1;
    // 대미지 판정을 적용할 범위
    public float damageRange;

    protected Rigidbody rigidbody;
    protected SphereCollider sphereCollider;

    // Enemy Layer 충돌
    protected LayerMask enemyLayer;


    protected void Awake()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
       GameObject.Find("GunAudio").GetComponent<AudioSource>().Play();

        sphereCollider = GetComponent<SphereCollider>();
        transform.position += transform.forward * (sphereCollider.radius + 0.5f);
    }

    protected void OnCollisionEnter(Collision other)
    {
        GameManager.instance.Explose(transform.position, damageRange, enemyLayer);

        Destroy(gameObject);
    }
}
