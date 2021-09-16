using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{

    private void Update()
    {
        print(transform.eulerAngles);
    }


    public void roationRight()
    {
       
        iTween.RotateBy(this.gameObject, iTween.Hash(
            "y",0.25f,
            "speed", 100f,
            "easetype", iTween.EaseType.easeInOutSine));

    }


    public void roationLeft()
    {
        iTween.RotateBy(this.gameObject, iTween.Hash(
            "y", -0.25f,
            "speed", 100f,
            "easetype", iTween.EaseType.easeInOutSine));
    }
}
