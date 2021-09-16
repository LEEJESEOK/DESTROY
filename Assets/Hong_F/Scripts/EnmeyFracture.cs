using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Fractures;
using UnityEngine.UI;


public class EnmeyFracture : MonoBehaviour
{
    public float hp = 1;
    GameObject fractureObj;
    public int currScore = 3;


    // Start is called before the first frame update
    void Start()
    {
        fractureObj = FractureThis.GetInstance().CreateFracture(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Score = GameObject.Find("ScoreText");
        //scoreText = Score.GetComponent<Text>();
        // if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        // {
        //     // TODO : 대미지 수치 적용
        //     hp -= 4;
        // }
    }

    public void OnHit(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            fractureObj.transform.position = transform.position;
            fractureObj.SetActive(true);
            fractureObj.gameObject.GetComponentInChildren<Rigidbody>().AddExplosionForce(10000, fractureObj.transform.position, 1);

            Destroy(fractureObj, 3);
            
            // TODO 획득점수 설정
            ScoreManager.instance.AddScore(currScore);

            Destroy(gameObject);
        }
    }
}
