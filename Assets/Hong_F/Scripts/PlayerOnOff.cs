using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnOff : MonoBehaviour
{
    GameObject Cube;
    GameObject Dia;
    GameObject Star;
    GameObject Heart;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        Cube = GameObject.Find("CubieBeveled");
        Dia = GameObject.Find("Diamondo");
        Star = GameObject.Find("SoftStar");
        Heart = GameObject.Find("Heart");

        Cube.SetActive(false);
        Dia.SetActive(false);
        Star.SetActive(false);
        Heart.SetActive(false);
        int select = PlayerPrefs.GetInt("CS");

        switch (select)
        {
            case 0:
                CubeOnOff();
                break;
            case 1:
                HeartOnOff();
                break;
            case 2:
                DiaOnOff();
                break;
            case 3:
                StarOnOff();
                break;
        }
    }

    public void CubeOnOff()
    {
        Cube.SetActive(true);
    }
    public void DiaOnOff()
    {
        Dia.SetActive(true);
    }

    public void StarOnOff()
    {
        Star.SetActive(true);
    }
    public void HeartOnOff()
    {
        Heart.SetActive(true);
    }
}
