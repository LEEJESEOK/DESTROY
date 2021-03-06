using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    public static AimManager instance;


    LayerMask groundLayer;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // TODO
        // Layermask 수정
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, groundLayer))
        {
            transform.position = new Vector3(hit.point.x, 0.1f, hit.point.z);

            transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
