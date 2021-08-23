using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float speed;
    public int damage;

    public GameObject originalBullet;

    List<GameObject> bullets = new List<GameObject>();

    public int maxBullet;
    public int maxAngle = 10;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < maxBullet; i++)
        {
            int randAngle = Random.Range(-maxAngle, maxAngle);
            print(i);

            bullets.Add(Instantiate(originalBullet));
            originalBullet.transform.position = transform.position;
            bullets[i].transform.Rotate(Vector3.up * randAngle);

            Bullet bulletComponent = bullets[i].GetComponent<Bullet>();
            bulletComponent.speed = speed;
            bulletComponent.damage = damage;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
