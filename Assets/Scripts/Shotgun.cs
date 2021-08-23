using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float speed;
    public int damage;

    public GameObject originalBullet;

    List<GameObject> bullets = new List<GameObject>();

    // 한 번 공격할 때의 총알 수, 각도
    public int maxBullet;
    public int maxAngle = 10;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxBullet; i++)
        {
            bullets.Add(Instantiate(originalBullet));

            originalBullet.transform.position = transform.position;
            // 총알마다 임의의 각도 지정
            int randAngle = Random.Range(-maxAngle, maxAngle);
            bullets[i].transform.Rotate(Vector3.up * randAngle);

            // 총알의 속도, 데미지
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
