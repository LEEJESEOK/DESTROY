using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrenade : Weapon
{
    public float fireAngle;


    public override void Attack(Vector3 position)
    {
        if ((currentBulletCnt < spendBulletCnt)/* || isOverheat == true*/)
            return;

        currentBulletCnt -= spendBulletCnt;
        UIManager.instance.SpendBullet(spendBulletCnt);

        GameObject projectile = Instantiate(bulletObj);
        projectile.transform.position = position + Vector3.up;
        projectile.transform.Rotate(projectile.transform.right * fireAngle * (-1));
        projectile.transform.forward = transform.forward;

        InitBulletProps(projectile, speed, damage);
    }
}
