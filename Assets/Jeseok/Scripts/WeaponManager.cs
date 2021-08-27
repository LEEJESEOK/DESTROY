using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    public GameObject[] weapons;
    Weapon weaponComponent;
    int activeWeaponIdx = 0;
    float attackDelay;
    bool isDelay = false;

    IEnumerator checkAttackDelayCoroutine;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);


        checkAttackDelayCoroutine = CheckAttackDelay();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitActiveWeapon();

    }

    // Update is called once per frame
    void Update()
    {

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

        weaponComponent.Attack(transform.position);

        isDelay = true;
    }

    public void ChangeWeapon(float idx)
    {
        weapons[activeWeaponIdx].SetActive(false);

        activeWeaponIdx += (idx > 0 ? 1 : -1) + weapons.Length;
        activeWeaponIdx %= weapons.Length;

        StopCoroutine(checkAttackDelayCoroutine);
        InitActiveWeapon();
    }

    void UpdateProps(float speed, float range, int damage, float delay)
    {

    }

    void InitActiveWeapon()
    {
        weaponComponent = weapons[activeWeaponIdx].GetComponent<Weapon>();
        attackDelay = weaponComponent.delay;

        StartCoroutine(checkAttackDelayCoroutine);
        weapons[activeWeaponIdx].SetActive(true);
    }

    IEnumerator CheckAttackDelay()
    {
        while (true)
        {
            yield return null;

            if (isDelay == true)
            {
                yield return new WaitForSeconds(attackDelay);

                isDelay = false;
            }
        }
    }
}
