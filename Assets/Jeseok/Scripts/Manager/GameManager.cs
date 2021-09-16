using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        Ready,
        Play,
        Die,
        Pause
    }

    public GameState gameState;

    public GameObject player;

    public GameObject floor;
    float xRange, zRange;

    System.Random rng = new System.Random();

    public int initBuildingCnt;

    public GameObject bulletItemObj;
    public float buildingSpawnTime = 10f;

    public int initBulletItemCnt = 30;

    public GameObject explosionEffect;
    public float bulletSpawnTime = 5f;

    public Material fractureMat;

    bool pauseToggle = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            gameState = GameState.Ready;
        }
        else
        {
            Destroy(gameObject);
        }

        // Enemy spawn Range
        xRange = floor.transform.localScale.x;
        zRange = floor.transform.localScale.z;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            // 메뉴에서 게임 시작, 재시작 선택했을 때
            // 게임준비
            case GameState.Ready:
                Ready();
                break;

            case GameState.Play:
                Play();
                break;

            // Player 사망
            case GameState.Die:
                Die();
                break;
            default:
                break;
        }

        // Game Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState = GameState.Pause;

            // resume
            if (pauseToggle == true)
                Resume();

            // pause
            else
                Pause();

            pauseToggle = !pauseToggle;
        }

    }

    void Ready()
    {
        // CreateBuildings
        CreateBuildings(initBuildingCnt);

        // create bullet item
        CreateBulletItems(initBulletItemCnt);

        StartCoroutine(SpawnBuilding());
        StartCoroutine(SpawnBulletItem());

        player.SetActive(true);

        gameState = GameState.Play;
    }

    void Play()
    {
        // 일정시간 마다 건물, 아이템 재생성
    }

    void Die()
    {

    }

    // 게임 일시정지
    // 인게임 메뉴
    public void Pause()
    {
        Time.timeScale = 0;

        // 인게임 메뉴
    }


    // 인게임 메뉴 제거
    // 게임 재시작
    public void Resume()
    {
        // 인게임 메뉴 제거

        Time.timeScale = 1;
    }

    Vector3 PlayerAroundRandomPosition()
    {
        Vector3 randPosition = Random.insideUnitCircle;
        Vector3 position = new Vector3(randPosition.x, 0, randPosition.y);
        position.Normalize();

        Vector3 target = player.transform.position;
        target.y = 0;

        return target + position * 30f;
    }

    void CreateBuildings(int buildingCnt)
    {
        for (int i = 0; i < buildingCnt; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-xRange, xRange) * 5, 0, Random.Range(-zRange, zRange) * 5);
            CreateBuilding(randPos);
        }
    }

    void CreateBuilding(Vector3 position)
    {
        float randHeight = (float)(rng.NextDouble() * (5));

        GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
        building.transform.localScale = new Vector3(1, randHeight, 1);
        building.transform.position = position + transform.up * randHeight * 0.5f;
        building.transform.Rotate(Vector3.up * 45);

        building.name = "Building";
        building.layer = LayerMask.NameToLayer("Building");
    }

    void CreateBulletItems(int bulletItemCnt)
    {
        for (int i = 0; i < bulletItemCnt; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-xRange, xRange) * 5, 0, Random.Range(-zRange, zRange) * 5);
            CreateBulletItem(randPos);
        }
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
    
    public void ExploseInDie(Vector3 position, float explosionRange, GameObject effectObj, LayerMask layer = new LayerMask())
    {
        GameObject explosion = Instantiate(effectObj);
        explosion.transform.position = position;
        explosion.transform.localScale *= explosionRange;

        Explose(position, explosionRange * 5, layer);
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
                enmeyFracture.OnHit(PreWeaponManager.instance.weaponComponent.damage);
            }
        }
    }

    // buildingSpawnTime 마다 building 생성    
    IEnumerator SpawnBuilding()
    {
        while (true)
        {
            yield return new WaitForSeconds(buildingSpawnTime);

            CreateBuilding(PlayerAroundRandomPosition());
        }
    }

    // bulletSpawnTime 마다 bulletItem 생성    
    IEnumerator SpawnBulletItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);

            CreateBulletItem(PlayerAroundRandomPosition());
        }
    }
}
