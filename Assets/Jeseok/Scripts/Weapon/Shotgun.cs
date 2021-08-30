using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    // x축으로 확산되는 범위(랜덤)
    public float diffuseRange;
    // 발사되는 각도(랜덤)
    public int maxAngle;

    public override void Attack(Vector3 position)
    {
        if (currentBulletCnt < spendBulletCnt)
            return;
            
        currentBulletCnt -= spendBulletCnt;
        BulletManager.instance.SpendBullet(spendBulletCnt);

        for (int i = 0; i < spendBulletCnt; i++)
        {
            GameObject projectile = Instantiate(bulletObj);
            projectile.transform.position = position;
            projectile.transform.forward = transform.forward;

            InitBulletProps(projectile, speed, damage, remainTime);

            float randDiffuse = Random.Range(-diffuseRange, diffuseRange);
            projectile.transform.position = position + transform.right * randDiffuse;

            // 총알마다 임의의 각도 지정
            int randAngle = Random.Range(-maxAngle, maxAngle);
            projectile.transform.Rotate(Vector3.up * randAngle);
        }
    }
}