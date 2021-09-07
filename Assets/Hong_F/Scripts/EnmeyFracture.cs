using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Fractures;


public class EnmeyFracture : MonoBehaviour
{
    public float hp = 1;
    GameObject fractureObj;
    
    
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            hp -= 4;
        }
    }

    public void OnHit(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            fractureObj.transform.position = transform.position;
            fractureObj.SetActive(true);
            fractureObj.gameObject.GetComponentInChildren<Rigidbody>().AddExplosionForce(10000, fractureObj.transform.position, 1);

            Destroy(fractureObj, 4);

            Destroy(gameObject);
        }
    }
}
