using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineManager : MonoBehaviour
{
    public static MagazineManager instance;

    public Text magazineText;

    public int maxMagazine;
    public int currentMagazine;


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
        currentMagazine = maxMagazine;
    }

    // Update is called once per frame
    void Update()
    {
        magazineText.text = "" + currentMagazine;
    }
}
