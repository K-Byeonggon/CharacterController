using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MoveInputSystem : MonoBehaviour
{
    [SerializeField] private Vector3 moveVector = Vector3.zero;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float gravity = 20f;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(moveVector * moveSpeed * Time.deltaTime);

        moveVector.y -= gravity * Time.deltaTime;
        characterController.Move(moveVector*moveSpeed*Time.deltaTime);

    }

    private void OnMove(InputValue inputValue)
    {
        Debug.Log(inputValue.Get<Vector3>());
        moveVector = inputValue.Get<Vector3>();
    }
}
