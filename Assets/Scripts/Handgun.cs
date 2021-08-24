using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
    public GameObject bulletObj;


    private void Start()
    {
    }

    public override void Attack(Vector3 position)
    {
        GameObject bullet = Instantiate(bulletObj);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bullet.transform.position = position;
        bulletComponent.speed = speed;
        bulletComponent.damage = damage;

        Destroy(bullet, range);
    }
}
