using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int maxHP;
    int currentHP;

    public GameObject destroyEffect;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
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
        GameObject destroyEft = Instantiate(destroyEffect);
        destroyEft.transform.position = gameObject.transform.position;

        Collider[] cols = Physics.OverlapSphere(transform.position, 5f, ~LayerMask.NameToLayer("Ground"));
        for (int i = cols.Length - 1; i >= 0; --i)
        {
            Destroy(cols[i].gameObject);
        }

        Destroy(gameObject);
    }

}
