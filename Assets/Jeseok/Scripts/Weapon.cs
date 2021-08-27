using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    // projectile 원형
    public GameObject bulletObj;

    // projectile 속도
    public float speed;
    // 사거리
    public float range;
    // 데미지
    public int damage;
    // 공격 딜레이(속도)
    public float delay;
    public int maxBulletCnt;
    public int currentBulletCnt;

    public bool hasWeapon { get; set; }


    virtual public void Attack(Vector3 position)
    {
        GameObject bullet = Instantiate(bulletObj);
        bullet.transform.position = position;
        bullet.transform.forward = transform.forward;

        InitBulletProps(bullet, speed, damage, range);
    }

    protected void InitBulletProps(GameObject bullet, float speed, int damage)
    {
        // 총알의 속도, 데미지
        Projectile projectile = bullet.GetComponent<Projectile>();
        projectile.speed = speed;
        projectile.damage = damage;
    }
    protected void InitBulletProps(GameObject bullet, float speed, int damage, float range)
    {
        InitBulletProps(bullet, speed, damage);

        Destroy(bullet, range);
    }
}
