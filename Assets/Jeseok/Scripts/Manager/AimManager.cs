using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimManager : MonoBehaviour
{
    public static AimManager instance;


    [HideInInspector]
    public float currentBullet;

    public Text bulletText;

    public Image Overheat;
    


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
        bulletText.text = "" + currentBullet;
    }

    public void SpendBullet(int bulletCnt)
    {
        currentBullet -= bulletCnt;
    }
}