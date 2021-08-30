using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
public class PlayerHP : MonoBehaviour
{
    public int maxHP;
    int currentHP;

    public GameObject explosionEffect;
    public float explosionRange = 20f;

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
        GameObject explosion = Instantiate(explosionEffect);
        explosion.transform.position = gameObject.transform.position;
        explosion.transform.localScale *= explosionRange;

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRange, ~LayerMask.NameToLayer("Ground"));
        for (int i = cols.Length - 1; i >= 0; --i)
        {
            //TODO 폭발 물리 효과
            Destroy(cols[i].gameObject);
        }

        Destroy(gameObject);
    }

}
