using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    // projectile 원형
    public GameObject bulletObj;

    // projectile 속도
    public float speed;
    // 사거리, 이후에 인스턴스 제거
    public float remainTime;
    // 데미지
    public int damage;
    // 공격 딜레이(속도)
    public float delay;

    // 소지 가능한 최대 Bullet 개수
    public float maxBulletCnt;
    // 현재 소지중인 Bullet 개수
    public float currentBulletCnt;

    // 한 번 공격할 때의 소모하는 Bullet 개수
    public int spendBulletCnt = 1;

    public bool hasWeapon { get; set; }


    virtual public void Attack(Vector3 position)
    {
        if (currentBulletCnt < spendBulletCnt)
            return;
            
        currentBulletCnt -= spendBulletCnt;
        AimManager.instance.SpendBullet(spendBulletCnt);

        GameObject bullet = Instantiate(bulletObj);
        bullet.transform.position = position;
        bullet.transform.rotation = transform.rotation;

        InitBulletProps(bullet, speed, damage, remainTime);
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
