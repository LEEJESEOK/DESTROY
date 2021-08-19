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
    }

    public void ChangeWeapon(int num)
    {

    }
}
