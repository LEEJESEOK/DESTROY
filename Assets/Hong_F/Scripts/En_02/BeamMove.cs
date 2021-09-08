using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using VolumetricLines;

public class BeamMove : MonoBehaviour
{
    float currTime;
    GameObject Player;
    GameObject beam;
    Vector3 one;
    Vector3 two;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        beam = GameObject.Find("SingleLine-LightSaber");

        beam.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {



        float DistanceX = Player.transform.position.x - transform.position.x;
        float DistanceZ = Player.transform.position.z - transform.position.z;

        if ((DistanceX <= 15 && DistanceZ <= 15) && (DistanceX > -15 && DistanceZ > -15))
        {
            currTime += Time.deltaTime;
            if (currTime > 2f)
            {

                beam.SetActive(true);


                //transform.LookAt(Player.transform.position);
                one = Vector3.Lerp(one, new Vector3(0, 0, 50), 10 * Time.deltaTime);
                       beam.GetComponent<VolumetricLineBehavior>().
                       SetStartAndEndPoints(one, new Vector3(0, 0, 0));

                //two = Vector3.Lerp(two, new Vector3(0, 0, 50), 10 * Time.deltaTime);
                //     beam.GetComponent<VolumetricLineBehavior>().
                //       SetStartAndEndPoints(one, two);





            }
        }
    }
}
