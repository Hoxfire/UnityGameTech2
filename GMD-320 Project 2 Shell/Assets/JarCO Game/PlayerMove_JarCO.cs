using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_JarCO : MonoBehaviour
{
    BaseMovement baseMovement;
    Vector2 moveInput;

    [Header("Player Rotation")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform playerModle;
    [SerializeField] float rotationSpeed = 7.0f;

    [Header("Player Movement")]
    [SerializeField] float moveSpeed;
    Vector3 moveDir;

    Rigidbody rb;
    Transform mainCamTrans;

    private void Awake()
    {
        baseMovement = new BaseMovement();
        baseMovement.Player.Movement.performed +=
            ctx => moveInput = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamTrans = Camera.main.transform;
    }

    private void Update()
    {
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void RotatePlayer() 
    {
        Vector3 viewDir = transform.position -
            new Vector3(mainCamTrans.position.x, transform.position.y, mainCamTrans.position.z);

        orientation.forward = viewDir.normalized;

        Vector3 inputDir = orientation.forward * moveInput.y + orientation.right * moveInput.x;

        if (inputDir != Vector3.zero)
        {
            playerModle.forward = Vector3.Slerp(playerModle.forward, inputDir.normalized, rotationSpeed * Time.deltaTime);
        }
    }

    void MovePlayer() 
    {
        moveDir = orientation.forward * moveInput.y + orientation.right * moveInput.x;

        rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.Force);
    }

    private void OnEnable()
    {
        baseMovement.Enable();
    }

    private void OnDisable()
    {
        baseMovement.Disable();
    }
}
