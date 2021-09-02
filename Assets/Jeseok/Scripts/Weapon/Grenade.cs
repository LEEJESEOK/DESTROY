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
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
        buildingLayer = 1 << LayerMask.NameToLayer("Building");

        mapLayer = (groundLayer | buildingLayer);
    }

    protected new void OnCollisionEnter(Collision other) {
        LayerMask otherLayer = 1 << other.gameObject.layer;

        if ((otherLayer & (enemyLayer | mapLayer)) != 0)
            transform.localScale = Vector3.one * damageRange;

        base.OnCollisionEnter(other);

        GameObject explosion = Instantiate(explosionEffect);
        explosion.transform.position = transform.position;


        //TODO 수류탄 폭발 효과
        Destroy(gameObject);
    }
}
