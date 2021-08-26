using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    // bullet 원형
    public GameObject bulletObj;

    // bullet 속도
    public float speed;
    // 사거리
    public float range;
    // 데미지
    public int damage;
    // 공격 딜레이(속도)
    public float delay;

    public bool hasWeapon { get; set; }


    virtual public void Attack(Vector3 position)
    {
        GameObject bullet = Instantiate(bulletObj);
        bullet.transform.position = position;
        bullet.transform.forward = transform.forward;

        InitBulletProps(bullet, speed, damage, range);
    }

    protected void InitBulletProps(GameObject bullet, float speed, int damage, float range)
    {
        // 총알의 속도, 데미지
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.speed = speed;
        bulletComponent.damage = damage;

        Destroy(bullet, range);
    }
}
