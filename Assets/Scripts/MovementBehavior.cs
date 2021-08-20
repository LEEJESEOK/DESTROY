using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    public void Move(Vector3 dir)
    {

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }

    public void Shot()
    {
        GameObject weapon = Instantiate(WeaponManager.instance.activeWeapon);
        weapon.transform.position = transform.position;

        float radian = Mathf.Atan2(Aim.instance.transform.localPosition.z, Aim.instance.transform.localPosition.x);
        float degree = Mathf.Rad2Deg * radian;
        weapon.transform.rotation = Quaternion.Euler(0, 90 + degree * (-1), 0);
    }

    public void ChangeWeapon(int num)
    {

    }
}
