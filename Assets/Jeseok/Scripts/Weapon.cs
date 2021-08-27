using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    // projectile 원형
    public GameObject bulletObj;

    // 한 번 공격할 때의 총알 수
    public int bulletCnt;

    // projectile 속도
    public float speed;
    // 사거리, 이후에 인스터늣 제거
    public float remainTime;
    // 데미지
    public int damage;
    // 공격 딜레이(속도)
    public float delay;

    public int maxBulletCnt;
    public int currentBulletCnt;
    [HideInInspector]
    public int spendBulletCnt;

    public bool hasWeapon { get; set; }

    private void Start()
    {
        spendBulletCnt = bulletCnt;
    }

    virtual public void Attack(Vector3 position)
    {
        GameObject bullet = Instantiate(bulletObj);
        bullet.transform.position = position;
        bullet.transform.forward = transform.forward;

        InitBulletProps(bullet, speed, damage, remainTime);

        MagazineManager.instance.SpendBullet(spendBulletCnt);
    }

    protected void InitBulletProps(GameObject bullet, float speed, int damage)
    {
        // 총알의 속도, 데미지
        Projectile projectile = bullet.GetComponent<Projectile>();
        projectile.speed = speed;
        projectile.damage = damage;
    }
    protected void InitBulletProps(GameObject bullet, float speed, int damage, float remainTime)
    {
        InitBulletProps(bullet, speed, damage);

        Destroy(bullet, remainTime);
    }
}
