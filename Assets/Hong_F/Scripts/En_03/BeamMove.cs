using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using VolumetricLines;

public class BeamMove : MonoBehaviour
{
    float currTime;
    GameObject Player;
    public GameObject bulletFactory;
    public GameObject firepos;
    public GameObject beam;
    Vector3 one;
    Vector3 two;
    public GameObject bullet;
    public GameObject aim;

    float z = 70;

    public enum ShotState
    {
        Shot,
        Back,
        Idle,
    }
    public ShotState state;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        // beam = GameObject.Find("SingleLine-LightSaber");

        beam.SetActive(false);
        state = ShotState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState != GameManager.GameState.Play)
            return;

        switch (state)
        {
            case ShotState.Idle:
                Move();
                break;
            case ShotState.Shot:
                ShotBeam();
                break;
            case ShotState.Back:
                BeamBack();
                break;
        }
    }

    public void Move()
    {
        float DistanceX = Player.transform.position.x - transform.position.x;
        float DistanceZ = Player.transform.position.z - transform.position.z;
        // if ((DistanceX <= 15 && DistanceZ <= 15) && (DistanceX > -15 && DistanceZ > -15))
        if (Vector3.Distance(Player.transform.position, transform.position) <= 15)
        {
            currTime += Time.deltaTime;

            if (currTime > 2f)
            {
                if (bullet.activeSelf == false)
                    bullet.SetActive(true);

                bullet.transform.position = firepos.transform.position;

                bullet.GetComponent<BeamBullet>().SetDest(aim.transform.position);

                currTime = 0f;
                state = ShotState.Shot;

            }
        }
    }

    public void ShotBeam()
    {
        currTime += Time.deltaTime;

        if (currTime >= 2f)
        {
            currTime = 0f;
            state = ShotState.Back;
            return;
        }

        beam.SetActive(true);
        //transform.LookAt(Player.transform.position);
        //one = Vector3.Lerp(one, new Vector3(0, -6, z), 10 * Time.deltaTime);
        //beam.GetComponent<VolumetricLineBehavior>().
        //SetStartAndEndPoints(one, new Vector3(0, 0, 0));
        one = Vector3.Lerp(one, new Vector3(0, -6, z), 10 * Time.deltaTime);
        beam.GetComponent<VolumetricLineBehavior>().
        SetStartAndEndPoints(Vector3.zero, one);

        // �Ѿ��ݶ��δ� ���� 



    }

    public void BeamBack()
    {
        currTime += Time.deltaTime;

        if (currTime >= 2f)
        {
            beam.SetActive(false);
            currTime = 0f;
            state = ShotState.Idle;
            return;
        }

        //transform.LookAt(Player.transform.position);
        one = Vector3.Lerp(one, new Vector3(0, 0, 0.1f), 10 * Time.deltaTime);
        beam.GetComponent<VolumetricLineBehavior>().
        SetStartAndEndPoints(one, new Vector3(0, 0, 0));
    }
}
