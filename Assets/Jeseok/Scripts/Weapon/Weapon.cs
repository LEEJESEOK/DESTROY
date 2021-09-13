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

    // 한 번 공격할 때의 생성하는 Bullet 개수
    public float spendBulletCnt = 1;


    public float maxOverheat = 100f;
    public float currentOverheat = 0f;
    public float cooldownRate = .2f;
    [HideInInspector]
    public bool isOverheat = false;

    private void Update()
    {
        // overheat cooldown
        currentOverheat -= Time.deltaTime * cooldownRate * 10;
        currentOverheat = Mathf.Clamp(currentOverheat, 0, maxOverheat);
        UIManager.instance.currentOverheat = currentOverheat;
    }

    virtual public void Attack(Vector3 position)
    {
        if ((currentBulletCnt < spendBulletCnt) || isOverheat == true)
            return;

        currentBulletCnt -= spendBulletCnt;
        UIManager.instance.SpendBullet(spendBulletCnt);

        GameObject bullet = Instantiate(bulletObj);
        bullet.transform.position = position;
        bullet.transform.rotation = transform.rotation;

        InitBulletProps(bullet, speed, damage, remainTime);


        // TODO 무기당 overheat 증가치 별도 적용
        currentOverheat += spendBulletCnt;
        UIManager.instance.AddHeat(spendBulletCnt);

        if (currentOverheat >= maxOverheat)
        {
            isOverheat = true;
            StartCoroutine(Cooldown(cooldownRate));
        }
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

    protected IEnumerator Cooldown(float cooldownRate)
    {
        while (currentOverheat > 0)
        {
            // yield return new WaitForSeconds(maxOverheat / cooldownRate);
            yield return new WaitForSeconds(1f);
            currentOverheat -= maxOverheat * cooldownRate;
        }
        isOverheat = false;
    }
}
