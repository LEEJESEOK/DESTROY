using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    // x축으로 확산되는 범위(랜덤)
    float diffuseXRange = 0.1f;
    public float diffuseYRange;
    // 발사되는 각도(랜덤)
    public int maxAngle;

    public override void Attack(Vector3 position)
    {
        if ((currentBulletCnt < spendBulletCnt) || isOverheat == true)
            return;

        currentBulletCnt -= spendBulletCnt;
        UIManager.instance.SpendBullet(spendBulletCnt);

        for (int i = 0; i < spendBulletCnt; i++)
        {
            GameObject projectile = Instantiate(bulletObj);
            projectile.transform.position = position;
            projectile.transform.forward = transform.forward;

            InitBulletProps(projectile, speed, damage, remainTime);

            float randDiffuseX = Random.Range(-diffuseXRange, diffuseXRange);
            float randDiffuseY = Random.Range(-diffuseYRange, diffuseYRange);
            projectile.transform.position = position + transform.right * randDiffuseX + transform.forward * randDiffuseY;

            // 총알마다 임의의 각도 지정
            int randAngle = Random.Range(-maxAngle, maxAngle);
            projectile.transform.Rotate(Vector3.up * randAngle);
        }

        

        // TODO 무기당 overheat 증가치 별도 적용
        currentOverheat += spendBulletCnt;
        UIManager.instance.AddHeat(spendBulletCnt);

        if (currentOverheat >= maxOverheat)
        {
            isOverheat = true;
            StartCoroutine(Cooldown(cooldownRate));
        }
    }
}
