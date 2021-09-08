using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public GameObject player;

    public GameObject floor;
    float xRange, zRange;

    public int buildingCnt;

    public GameObject bulletItemObj;
    public int initBulletItemCnt = 30;

    public GameObject explosionEffect;

    public Material fractureMat;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        xRange = floor.transform.localScale.x;
        zRange = floor.transform.localScale.z;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buildingCnt; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-xRange, xRange) * 5, 0, Random.Range(-zRange, zRange) * 5);
            float randHeight = Random.Range(1f, 5f);
            CreateBuilding(randPos, randHeight);
        }

        for (int i = 0; i < initBulletItemCnt; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-xRange, xRange) * 5, 0, Random.Range(-zRange, zRange) * 5);
            CreateBulletItem(randPos);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBuilding(Vector3 position, float height)
    {
        GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.transform.localScale = new Vector3(1, height, 1);
        building.transform.position = position + transform.up * height * 0.5f;
        building.transform.Rotate(Vector3.up * 45);

        building.name = "Building";
        building.layer = LayerMask.NameToLayer("Building");
    }

    void CreateBulletItem(Vector3 position)
    {
        GameObject bulletItem = Instantiate(bulletItemObj);
        bulletItem.transform.position = position + transform.up * bulletItem.transform.localScale.y * 0.5f;

        bulletItem.name = "BulletItem";
        bulletItem.layer = LayerMask.NameToLayer("Item");
    }

    public void ExploseWithEffect(Vector3 position, float explosionRange, LayerMask layer = new LayerMask())
    {
        GameObject explosion = Instantiate(explosionEffect);
        explosion.transform.position = position;
        explosion.transform.localScale *= explosionRange;

        Explose(position, explosionRange, layer);
    }

    public void Explose(Vector3 position, float explosionRange, LayerMask layer = new LayerMask())
    {
        Collider[] cols = Physics.OverlapSphere(position, explosionRange, layer);
        for (int i = cols.Length - 1; i >= 0; --i)
        {
            Rigidbody tempRb = cols[i].gameObject.GetComponent<Rigidbody>();
            if (tempRb != null)
            {
                Vector3 dir = cols[i].gameObject.transform.position - position;
                dir.Normalize();
                tempRb.AddExplosionForce(5000, position, explosionRange);
            }

            EnmeyFracture enmeyFracture = cols[i].gameObject.GetComponentInParent<EnmeyFracture>();
            if (enmeyFracture != null)
            {
                enmeyFracture.OnHit(PreWeaponManager.instance.mainWeaponComponent.damage);
            }
        }
    }
}
