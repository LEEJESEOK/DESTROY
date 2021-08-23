using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementBehavior movementBehavior;

    // Start is called before the first frame update
    void Start()
    {
        movementBehavior = GetComponent<MovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        movementBehavior.Move(dir);

        // Attack
        if (Input.GetButton("Fire1"))
            movementBehavior.Attack();

        // TODO ChangeWeapon

    }
}
