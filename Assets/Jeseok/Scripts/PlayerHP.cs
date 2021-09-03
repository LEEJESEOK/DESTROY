using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
public class PlayerHP : MonoBehaviour
{
    public int maxHP;
    int currentHP;


    public float explosionRange = 10f;

    public Image hPUI;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(other.gameObject);
            //TODO 데미지 수치 적용
            --currentHP;
            print(currentHP / maxHP);

            hPUI.fillAmount = (float)currentHP / maxHP;


            if (currentHP <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        GameManager.instance.Explose(transform.position, explosionRange);
        Destroy(gameObject);
    }

}
