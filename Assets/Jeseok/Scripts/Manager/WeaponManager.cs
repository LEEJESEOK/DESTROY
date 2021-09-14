using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;


    public List<GameObject> hasWeaponList;
    [HideInInspector]
    public Weapon activeWeapon;
    public Weapon defaultWeapon;

    public GameObject[] weaponObj;
    public GameObject weaponUIObj;

    bool isDelay = false;
    float attackDelay;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitWeapon();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeWeapon()
    {
        StopCoroutine(CheckAttackDelay());

        InitWeapon();
    }

    void InitWeapon()
    {
        // change active weapon component
        // activeWeapon = GetComponent<Weapon>();
        // update attack delay

        // attackDelay = ;
        StartCoroutine(CheckAttackDelay());
    }

    public void Attack()
    {
        if (isDelay == true)
            return;

        // activeWeaponComponent.Attack(transform.position);

        isDelay = true;
    }

    // bullet 획득, 추가 함수
    public void AddBullet(int bulletCnt)
    {
        // weaponComponent.currentBulletCnt += bulletCnt;
        // weaponComponent.currentBulletCnt = Mathf.Min(weaponComponent.currentBulletCnt, weaponComponent.maxBulletCnt);

        // UIManager.instance.currentBullet = weaponComponent.currentBulletCnt;
    }

    // Weapon.attackDelay 이후에 isDelay 플래그 전환
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
