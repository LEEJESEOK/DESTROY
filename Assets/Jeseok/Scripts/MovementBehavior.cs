using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    public void Move(Vector3 dir)
    {
        characterController.SimpleMove(dir * moveSpeed);
    }
}
