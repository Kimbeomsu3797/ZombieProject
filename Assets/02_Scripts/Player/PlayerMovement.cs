using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    Vector3 m_Input;

    Animator anim;
    Rigidbody rig;
    CapsuleCollider capCol;
    PlayerInput playerInput;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        Rotate();

        Move();

        anim.SetFloat("Move", playerInput.move);
    }

    void Move()
    {
        Vector3 moveDis = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;

        rig.MovePosition(rig.position + moveDis);
    }

    void Rotate()
    {
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;

        rig.rotation = rig.rotation * Quaternion.Euler(0, turn, 0f);
    }
}
