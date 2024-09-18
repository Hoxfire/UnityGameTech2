using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using Physics = RotaryHeart.Lib.PhysicsExtension.Physics;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField] Rigidbody rb;
    Collider car;
    public float speed = 10.0f;
    public float carSpeed = 10.0f;
    public float turnSpeed = 10.0f;

    Vector2 horizontalInput;

    [SerializeField] float gravity = -20.0f;
    Vector3 VertivalVolocity;

    [SerializeField] LayerMask groundLayer;
    bool isGrounded = false;

    bool isJumping = false;
    [SerializeField] float jumpHeight = 3.5f;

    //Control switch
    public InputState inputState = InputState.PlayerInput;

    private void Awake()
    {
        inputState = InputState.PlayerInput;
        car = gameObject.GetComponent<BoxCollider>();
        //GameObject.Find("Pizza Manager").GetComponent<pizzaMannager>().NextStop();
    }

    void Update()
    {
        VertivalVolocity.y += gravity * Time.deltaTime;
        CheckGround();
        //NormalMove();
        
        switch (inputState)
        {
            case InputState.PlayerInput:
                rb.isKinematic = true;
                characterController.enabled = true;
                car.enabled = false;   
                NormalMove();
                break;
            case InputState.CarInput:
                rb.isKinematic = false;
                characterController.enabled = false;
                car.enabled = true;
                CarMove();
                break;
            case InputState.Keyboard:
                break;
            case InputState.Controller:
                break;
            default:
                break;
        }
        
    }

    public void SwitchInput() 
    {
        //GameObject.Find("Pizza Manager").GetComponent<pizzaMannager>().NextStop();
        
        Debug.Log("Switch!");
        switch (inputState)
        {
            case InputState.PlayerInput:
                if (gameObject.GetComponent<PlayerSelect>().hit.collider.CompareTag("Car"))
                {
                    inputState = InputState.CarInput;

                    transform.position = GameObject.Find("body").transform.position;
                    transform.rotation = GameObject.Find("body").transform.localRotation;
                    Camera.main.transform.rotation = GameObject.Find("body").transform.localRotation;
                    GameObject.Find("body").transform.parent = transform;
                }
                break;
            case InputState.CarInput:
                inputState = InputState.PlayerInput;
                GameObject.Find("body").transform.parent = null;
                break;
            default:
                break;
        }
        
    }

    void NormalMove() 
    {
        rb.useGravity = false;
        Vector3 john = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        characterController.Move(john * Time.deltaTime);

        characterController.Move(VertivalVolocity * Time.deltaTime);
        if (isJumping)
        {
            jump();
        }
    }

    void CarMove() 
    {
        rb.useGravity = true;
        Vector3 john = (transform.forward * (Input.GetAxis("Pedle") * -1))*carSpeed ;
        Vector3 james = (transform.up * Input.GetAxis("Horizontal")) * turnSpeed;

        //Debug.Log(john + (transform.right * horizontalInput.x));

        rb.AddForce(john);

        //transform.Rotate(transform.up , james.y * Time.deltaTime);
        //rb.AddRelativeForce(james * Time.deltaTime);
        transform.Rotate(james * Time.deltaTime);
    }

    public void shouldJump()
    {
        isJumping = true;
    }

    void jump()
    {
        if (isGrounded)     
        {
            VertivalVolocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
        }

        isJumping = false;
    }

    void CheckGround() 
    {
        isGrounded = Physics.CheckSphere(transform.position + new Vector3(0,0.5f,0), 0.6f, 
        groundLayer, RotaryHeart.Lib.PhysicsExtension.PreviewCondition.Editor);

        //Debug.Log(isGrounded);

        if (isGrounded && VertivalVolocity.y < 0)
        {
            VertivalVolocity.y = 0;
        }
    }

    public void ReciveInput(Vector3 _horizontalInput) 
    {
        horizontalInput = _horizontalInput;
    }
}

public enum InputState 
{
    PlayerInput,
    CarInput,
    Keyboard,
    Controller
}
