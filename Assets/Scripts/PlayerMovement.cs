using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody playerRigidbody;
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()//�Է��� update��
    {
        
    }
    private void FixedUpdate()//���� ���� �ֱ⿡ ���� ������Ʈ // �̵��� fixedupdate��
    {
        Rotate();
        Move();
        playerAnimator.SetFloat("Move", playerInput.move);
    }
    private void Move()
    {
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }
    private void Rotate()
    {
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }
}
