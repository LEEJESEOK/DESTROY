using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    public GameObject bulletObj;


    public override void Attack(Vector3 position)
    {
        GameObject bullet = Instantiate(bulletObj);
        bullet.transform.position = position;
        bullet.transform.forward = transform.forward;

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.speed = speed;
        bulletComponent.damage = damage;

        Destroy(bullet, range);
    }
}
