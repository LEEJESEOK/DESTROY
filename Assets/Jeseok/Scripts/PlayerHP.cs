using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
public class PlayerHP : MonoBehaviour
{
    public float explosionRange = 10f;

    public int maxHP;
    int currentHP;


    public Image hpGauge;
    public Text hpTextUI;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        hpTextUI.text = "" + currentHP;
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

            hpGauge.fillAmount = (float)currentHP / maxHP;
            hpTextUI.text = "" + currentHP;

            if (currentHP <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        LayerMask layer = LayerMask.GetMask("Ground");

        GameManager.instance.ExploseWithEffect(transform.position, explosionRange, ~layer);
    }
}
