using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player_Wakefield : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed = 5.0f;
    public float AirMoveSpeed = 3.0f;
    public float maxSpeed = 5.0f;
    Vector3 MoveDirection;
    [SerializeField] Transform orientation;
    [SerializeField] Transform playerObj;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform mainCamera;
    [SerializeField] float rotSpeed = 7.0f;

    Vector2 movement;

    BaseMovement baseMovement;
    //CharacterController characterController;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isGrounded;

    [Header("Drag")]
    [SerializeField] float Drag = 5.0f;
    [SerializeField] float AirDrag = 7.0f;

    [Header("Jump")]
    [SerializeField] bool shouldJump = false;
    [SerializeField] float JumpForce = 10f;

    private void Awake()
    {
        //characterController = GetComponent<CharacterController>();

        baseMovement = new BaseMovement();

        baseMovement.Player.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;

        
    }

    private void OnEnable()
    {
        baseMovement.Enable();
    }


    private void OnDisable()
    {
       
        baseMovement.Disable();
    }

    private void Update()
    {
        if (GameManager_RW.TimeScale != 0)
        {

            CheckGround();
            RotatePlayer();
            if(baseMovement.Player.Jump.WasPressedThisFrame() && isGrounded)
            {
                Jump();
            }
            CapSpeed();
        }
    }

    private void FixedUpdate()
    {
        if (GameManager_RW.TimeScale != 0)
        {
            MovePlayer();
        }
    }

    public void RotatePlayer()
    {
        Vector3 viewDir = transform.position - new Vector3(mainCamera.position.x, transform.position.y, mainCamera.position.z);
        orientation.forward = viewDir.normalized;

        Vector3 inputDir = orientation.forward * movement.y + orientation.right * movement.x;
        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotSpeed);
        }

    }

    public void MovePlayer()
    {
        MoveDirection = orientation.forward * movement.y + orientation.right * movement.x;
        if (isGrounded)
        {
            rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(MoveDirection.normalized * AirMoveSpeed * 10f, ForceMode.Force);

        }
    }

    public bool CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.7f, groundMask);

        if (isGrounded)
        {
            rb.drag = Drag;
        }
        else
        {
            rb.drag = 0;
        }

        return isGrounded;
    }

    public void CapSpeed()
    {
        Vector3 currentVelcity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if(currentVelcity.magnitude > maxSpeed)
        {
            Vector3 maxVel = currentVelcity.normalized * maxSpeed;
            maxVel.y = rb.velocity.y; 
            rb.velocity = maxVel;
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }
}
