using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 300f;

    CharacterController controller;
    Vector3 moveDirection;
    float jumpSpeed = 10f;
    float gravity = 20f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (controller.isGrounded)
        {
            float amtRot = rotationSpeed * Time.deltaTime;
            float ver = Input.GetAxis("Vertical");   //축 가져오기
            float ang = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up * ang * amtRot);

            moveDirection = new Vector3(0, 0, ver * moveSpeed);

            moveDirection = transform.TransformDirection(moveDirection);    //이동방향을 오브젝트의 로컬좌표에서 월드좌표로 바꿔줌.

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity*Time.deltaTime;

        controller.Move(moveDirection*Time.deltaTime);
    }
}
