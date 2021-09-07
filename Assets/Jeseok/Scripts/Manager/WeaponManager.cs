using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;


    public GameObject[] weapons;
    [HideInInspector]
    public Weapon weaponComponent;
    int activeWeaponIdx = 0;
    float attackDelay;
    bool isDelay = false;
    public GameObject defaultWeapon;

    IEnumerator checkAttackDelayCoroutine;

    public Text mainWeaponText, subWeaponText;
    public Image mainWeaponGauge, subWeaponGauge;


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

        AimManager.instance.currentBullet = weaponComponent.currentBulletCnt;

        mainWeaponText.text = weapons[activeWeaponIdx].name;
    }

    public void AddBullet(int bulletCnt)
    {
        if (weaponComponent.currentBulletCnt + bulletCnt >= weaponComponent.maxBulletCnt)
        {
            weaponComponent.currentBulletCnt = weaponComponent.maxBulletCnt;
        }
        else
        {
            weaponComponent.currentBulletCnt += bulletCnt;
        }

        AimManager.instance.currentBullet = weaponComponent.currentBulletCnt;
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
