using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    public GameObject bulletObj;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Attack(Vector3 position)
    {
        GameObject bullet = Instantiate(bulletObj);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bullet.transform.position = position;
        bulletComponent.speed = speed;
        bulletComponent.damage = damage;

        Destroy(bullet, range);
    }
}
