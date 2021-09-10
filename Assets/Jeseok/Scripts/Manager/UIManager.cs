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
    public float maxHeat = 100;
    public float currentOverheat;
    public float cooldownRate = 1f;

    public Text weaponText;
    public Image weaponGauge;




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

    }

    private void Update()
    {
        // overheat cooldown
        currentOverheat -= Time.deltaTime * cooldownRate;
        currentOverheat = Mathf.Clamp(currentOverheat, 0, 100);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // bullet text
        bulletText.text = "" + currentBullet;

        // overheat gauge
        overheatGauge.fillAmount = currentOverheat / maxHeat;

        // weapon bullet gauge
        weaponGauge.fillAmount = currentBullet / maxBullet;
    }

    public void SpendBullet(float bulletCnt)
    {
        currentBullet -= bulletCnt;
        AddHeat(bulletCnt);
    }

    void AddHeat(float heat)
    {
        currentOverheat += heat;
    }

    public void ChangeWeapon(Weapon weaponComponent)
    {
        weaponText.text = weaponComponent.gameObject.name;

        maxBullet = weaponComponent.maxBulletCnt;
        currentBullet = weaponComponent.currentBulletCnt;
    }
}
