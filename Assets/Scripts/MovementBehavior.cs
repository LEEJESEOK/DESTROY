using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private float currTime = 0f;

    private void Update()
    {
        currTime += Time.deltaTime;
    }

    public void Move(Vector3 dir)
    {
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }

    public void Attack()
    {
        // if (currTime > WeaponManager.instance.activeWeapon.getCoolDown())
        // {
        //     GameObject weapon = Instantiate(WeaponManager.instance.activeWeapon.gameObject);
        //     weapon.transform.position = transform.position;

        //     // Crosshair와 Player의 위치차이로 각도 계산
        //     float radian = Mathf.Atan2(Aim.instance.transform.localPosition.z, Aim.instance.transform.localPosition.x);
        //     float degree = Mathf.Rad2Deg * radian;
        //     // 공격하는 각도 변경
        //     weapon.transform.rotation = Quaternion.Euler(0, 90 + degree * (-1), 0);

        //     currTime = 0;
        // }
    }
}
