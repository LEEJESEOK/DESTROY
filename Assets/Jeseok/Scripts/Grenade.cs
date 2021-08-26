using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Projectile
{
    [SerializeField]
     SphereCollider sphereCollider;

    private void OnTriggerEnter(Collider other)
    {
        sphereCollider.radius = 3f;
    }
}
