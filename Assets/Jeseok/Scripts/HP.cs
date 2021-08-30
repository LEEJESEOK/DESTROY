using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class HP : MonoBehaviour
{
    public int maxHP;
    int currentHP;

    public GameObject explosionEffect;
    public float explosionRange = 20f;


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
            --currentHP;
            print(currentHP);

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
