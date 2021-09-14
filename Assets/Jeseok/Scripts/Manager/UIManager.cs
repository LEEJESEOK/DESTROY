using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    public Text bulletText;
    public float maxBullet;
    public float currentBullet;

    public Image overheatGauge;
    public float maxOverheat = 100;
    public float currentOverheat;

    public Text weaponText;
    public Image weaponGauge;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // bullet text
        bulletText.text = "" + currentBullet;

        // overheat gauge
        overheatGauge.fillAmount = currentOverheat / maxOverheat;
        overheatGauge.color = new Color(1f, 1f - overheatGauge.fillAmount, 0);

        // weapon bullet gauge
        weaponGauge.fillAmount = currentBullet / maxBullet;
    }

    public void SpendBullet(float bulletCnt)
    {
        currentBullet -= bulletCnt;
    }

    public void AddHeat(float heat)
    {
        currentOverheat += heat;
    }

    public void ChangeWeapon(Weapon weaponComponent)
    {
        weaponText.text = weaponComponent.gameObject.name;

        maxBullet = weaponComponent.maxBulletCnt;
        currentBullet = weaponComponent.currentBulletCnt;
        maxOverheat = weaponComponent.maxOverheat;
        currentOverheat = weaponComponent.currentOverheat;
    }
}
