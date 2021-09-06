using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Projectile
{
    LayerMask mapLayer;
    LayerMask groundLayer;
    LayerMask buildingLayer;

    public GameObject explosionEffect;


    protected new void Awake()
    {
        base.Awake();
        groundLayer = LayerMask.GetMask("Ground");
        buildingLayer = LayerMask.GetMask("Building");

        mapLayer = (groundLayer | buildingLayer);
    }

    protected new void OnCollisionEnter(Collision other)
    {
        // 충돌한 오브젝트의 레이어
        LayerMask otherLayer = 1 << other.gameObject.layer;

        // 충돌한 오브젝트가 Enemy or Map(지형, 건물)에 해당
        if ((otherLayer & (enemyLayer | mapLayer)) != 0)
            transform.localScale = Vector3.one * damageRange;

        LayerMask layer = LayerMask.GetMask("Enemy");

        GameManager.instance.ExploseWithEffect(transform.position, damageRange, layer);



        //TODO 수류탄 폭발 효과
        // Destroy(gameObject);
    }
}
