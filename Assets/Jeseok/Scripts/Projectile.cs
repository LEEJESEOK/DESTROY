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
    // 데미지 판정을 적용할 범위
    public float damageRange;

    protected new Rigidbody rigidbody;
    protected SphereCollider sphereCollider;

    // Enemy Layer 충돌
    protected LayerMask enemyLayer;


    protected void Awake()
    {
        enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
    }

    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);

        sphereCollider = GetComponent<SphereCollider>();
        transform.position += transform.forward * (sphereCollider.radius + 0.5f);
    }

    protected void OnTriggerEnter(Collider other)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, damageRange, enemyLayer);
        for (int i = cols.Length - 1; i >= 0; --i)
        {
            //TODO damage 판정 함수 호출
            Destroy(cols[i].gameObject);
        }
    }
}
