using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject bulletObj;


    // 한 번 공격할 때의 총알 수, 각도
    public int maxBullet;
    public float diffuseRange;
    public int maxAngle;


    public override void Attack(Vector3 position)
    {

        for (int i = 0; i < maxBullet; i++)
        {
        GameObject bullet = Instantiate(bulletObj);
        bullet.transform.position = position;
        bullet.transform.forward = transform.forward;

            float randDiffuse = Random.Range(-diffuseRange, diffuseRange);
            bullet.transform.position = position + transform.right * randDiffuse;

            // 총알마다 임의의 각도 지정
            int randAngle = Random.Range(-maxAngle, maxAngle);
            bullet.transform.Rotate(Vector3.up * randAngle);

            // 총알의 속도, 데미지
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.speed = speed;
            bulletComponent.damage = damage;

            Destroy(bullet, range);
        }
    }
}
