using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    public Weapon[] weapons;
    // public Weapon defaultWeapon;
    [HideInInspector]
    public Weapon activeWeapon;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // defaultWeapon = weapons[0];
        // activeWeapon = defaultWeapon;
        activeWeapon = weapons[0];

    }

    private void Update()
    {
        switch (Input.inputString)
        {
            case "1":
                activeWeapon = weapons[0];
                print(activeWeapon.getCoolDown());
                break;
            case "2":
                activeWeapon = weapons[1];
                print(activeWeapon.getCoolDown());
                break;
        }
    }
}
