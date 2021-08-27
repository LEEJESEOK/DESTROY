using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrenade : Weapon
{
    public float fireAngle;


    public override void Attack(Vector3 position)
    {
        GameObject projectile = Instantiate(bulletObj);
        projectile.transform.position = position;
        projectile.transform.Rotate(projectile.transform.right * fireAngle * (-1));
        projectile.transform.forward = transform.forward;

        InitBulletProps(projectile, speed, damage);
    }
}
