using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private void Start()
    {
        Destroy(gameObject, .3f);
    }
}