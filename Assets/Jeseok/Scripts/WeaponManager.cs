using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;


    public GameObject[] weapons;

    int activeWeaponIdx = 0;
    //TODO Weapon 클래스 상속으로 변경
    float attackDelay;
    public bool isDelay = false;


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
        ChangeWeapon(activeWeaponIdx);
    }

    // Update is called once per frame
    void Update()
    {
        // 무기 교체(ChangeWeapon)
        // 마우스 휠
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput != 0)
        {
            weapons[activeWeaponIdx].SetActive(false);

            if (wheelInput > 0)
            {
                activeWeaponIdx = (activeWeaponIdx + 1) % weapons.Length;
            }
            else if (wheelInput < 0)
            {
                activeWeaponIdx = (activeWeaponIdx - 1 + weapons.Length) % weapons.Length;
            }

            ChangeWeapon(activeWeaponIdx);
        }
    }

    public void Attack()
    {
        if (isDelay == true)
            return;

        // Crosshair - Aim과 Player의 위치차이로 각도 계산
        float radian = Mathf.Atan2(Aim.instance.transform.localPosition.z, Aim.instance.transform.localPosition.x);
        float degree = Mathf.Rad2Deg * radian;
        // 공격하는 각도 변경
        transform.rotation = Quaternion.Euler(0, 90 + degree * (-1), 0);

        weapons[activeWeaponIdx].GetComponent<Weapon>().Attack(transform.position);

        isDelay = true;
        StartCoroutine(CheckAttackDelay());
    }

    void ChangeWeapon(int idx)
    {
        weapons[activeWeaponIdx].SetActive(true);
        attackDelay = weapons[activeWeaponIdx].GetComponent<Weapon>().delay;
    }
    
    void UpdateProps(float speed, float range, int damage, float delay)
    {

    }

    IEnumerator CheckAttackDelay()
    {
        yield return new WaitForSecondsRealtime(attackDelay);
        isDelay = false;
    }
}
