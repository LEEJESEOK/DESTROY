using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class En_03Move : MonoBehaviour
{
    public GameObject target;
    BeamMove bm;
    NavMeshAgent nav;
    public GameObject beam;
    float currTime;
    bool bbeam;

    Quaternion rota;

    public enum Movestate
    {
        Attack,
        NotAttack
    }

    public Movestate movestate;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");

        nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState != GameManager.GameState.Play)
            return;

        currTime += Time.deltaTime;


        //switch (movestate)
        //{

        //    case Movestate.Attack:

        //break;
        //case Movestate.NotAttack:
        //break;
        bm = beam.GetComponent<BeamMove>();

        if (bm != null)
            bbeam = bm.beam.activeSelf;

        if (bm.state == BeamMove.ShotState.Idle)
            rotation();
    }

    public void rotation()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.y = 0;
        dir.Normalize();

        //Quaternion q = Quaternion.Euler(dir);

        Quaternion q = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2 * Time.deltaTime); ;

        nav.SetDestination(target.transform.position);
    }

    void StopMove()
    {

    }

    void KeepMove()
    {

    }
}
