using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PreWeaponManager : MonoBehaviour
{
    public static PreWeaponManager instance;


    public GameObject[] weaponsObj;
    Stack<GameObject> weapons;

    [HideInInspector]
    public Weapon weaponComponent;
    int activeWeaponIdx = 0;
    float attackDelay;
    bool isDelay = false;
    public GameObject defaultWeapon;

    IEnumerator checkAttackDelayCoroutine;

    public GameObject weaponUI;
    public Text weaponText;
    public Image weaponGauge;


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
        weaponsObj[activeWeaponIdx].SetActive(false);

        activeWeaponIdx += (idx > 0 ? 1 : -1) + weaponsObj.Length;
        activeWeaponIdx %= weaponsObj.Length;

        StopCoroutine(checkAttackDelayCoroutine);
        InitActiveWeapon();
    }

    public void ChangeWeapon(int idx)
    {
        weaponsObj[activeWeaponIdx].SetActive(false);
        weaponComponent.isActive = false;

        activeWeaponIdx = idx;

        StopCoroutine(checkAttackDelayCoroutine);
        InitActiveWeapon();
    }

    void UpdateProps(float speed, float range, int damage, float delay)
    {

    }

    void InitActiveWeapon()
    {
        weaponComponent = weaponsObj[activeWeaponIdx].GetComponent<Weapon>();

        attackDelay = weaponComponent.delay;

        StartCoroutine(checkAttackDelayCoroutine);
        weaponsObj[activeWeaponIdx].SetActive(true);

        AimManager.instance.currentBullet = weaponComponent.currentBulletCnt;

        weaponText.text = weaponsObj[activeWeaponIdx].name;
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
