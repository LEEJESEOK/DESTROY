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

        activeWeaponIdx = idx;

        StopCoroutine(checkAttackDelayCoroutine);
        InitActiveWeapon();
    }

    // TODO 장비 강화
    void UpdateProps(float speed, float range, int damage, float delay)
    {

    }

    void InitActiveWeapon()
    {
        weaponComponent = weaponsObj[activeWeaponIdx].GetComponent<Weapon>();

        attackDelay = weaponComponent.delay;

        StartCoroutine(checkAttackDelayCoroutine);
        weaponsObj[activeWeaponIdx].SetActive(true);

        UIManager.instance.ChangeWeapon(weaponComponent);
    }

    // bullet 획득, 추가 함수
    public void AddBullet(int bulletCnt)
    {
        weaponComponent.currentBulletCnt += bulletCnt;
        weaponComponent.currentBulletCnt = Mathf.Min(weaponComponent.currentBulletCnt, weaponComponent.maxBulletCnt);

        UIManager.instance.currentBullet = weaponComponent.currentBulletCnt;
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
