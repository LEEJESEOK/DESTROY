using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    float currTime = 0f;
    public bool canAttack;

    public GameObject[] weapons;
    int activeWeaponIdx = 0;
    //TODO Weapon 클래스 상속으로 변경
    float attackDelay = 0.5f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(weapons[activeWeaponIdx].name);

        if (canAttack == false)
            currTime += Time.deltaTime;

        if (currTime > attackDelay)
        {
            canAttack = true;
            currTime = 0;
        }


        // 무기 교체(ChangeWeapon)
        // 마우스 휠
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput > 0)
        {
            activeWeaponIdx = (activeWeaponIdx + 1) % weapons.Length;
            ChangeWeapon(activeWeaponIdx);
        }
        else if (wheelInput < 0)
        {
            activeWeaponIdx = (activeWeaponIdx - 1 + weapons.Length) % weapons.Length;
            ChangeWeapon(activeWeaponIdx);
        }
    }

    public void Attack()
    {
        if (canAttack == false)
            return;

        GameObject range = Instantiate(weapons[activeWeaponIdx]);
        range.transform.position = transform.position;

        // Crosshair와 Player의 위치차이로 각도 계산
        float radian = Mathf.Atan2(Aim.instance.transform.localPosition.z, Aim.instance.transform.localPosition.x);
        float degree = Mathf.Rad2Deg * radian;
        // 공격하는 각도 변경
        range.transform.rotation = Quaternion.Euler(0, 90 + degree * (-1), 0);



        currTime = 0;
        canAttack = false;
    }

    void ChangeWeapon(int idx)
    {
        currTime = 0;
        canAttack = false;
    }
}
