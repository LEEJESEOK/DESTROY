using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OverheatManager : MonoBehaviour
{
    public static OverheatManager instance;


    Image overheatImage;

    float maxHeat = 100;
    float currentHeat;

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
        overheatImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        overheatImage.fillAmount = currentHeat / maxHeat;

        currentHeat -= Time.deltaTime;
    }

    void AddHeat(float heat)
    {
        currentHeat += heat;
    }
}
