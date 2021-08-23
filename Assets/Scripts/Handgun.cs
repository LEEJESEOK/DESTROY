using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour
{
    public float speed;
    public float delay;
    public int damage;

    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.speed = speed;
        bulletComponent.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
