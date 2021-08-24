using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    public float speed;
    public float range;
    public int damage;
    public float delay;

    public bool hasWeapon { get; set; }


    abstract public void Attack(Vector3 position);
}
