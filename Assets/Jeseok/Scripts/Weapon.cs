using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    public GameObject bulletObj;

    public float speed;
    public float range;
    public int damage;
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
