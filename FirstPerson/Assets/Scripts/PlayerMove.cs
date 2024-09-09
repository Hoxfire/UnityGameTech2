using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Physics = RotaryHeart.Lib.PhysicsExtension.Physics;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10.0f;
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
    }

    void Update()
    {
        VertivalVolocity.y += gravity * Time.deltaTime;
        characterController.Move(VertivalVolocity * Time.deltaTime);
        CheckGround();
        //NormalMove();
        
        switch (inputState)
        {
            case InputState.PlayerInput:
                NormalMove();
                //SwitchInput();
                break;
            case InputState.CarInput:
                CarMove();
                //SwitchInput();
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
        Debug.Log("Switch!");
        switch (inputState)
        {
            case InputState.PlayerInput:
                inputState = InputState.CarInput;
                break;
            case InputState.CarInput:
                inputState = InputState.PlayerInput;
                break;
            default:
                break;
        }
    }

    void NormalMove() 
    {
        Vector3 john = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        characterController.Move(john * Time.deltaTime);

        if (isJumping)
        {
            jump();
        }
    }

    void CarMove() 
    {
        Vector3 john = (transform.forward * horizontalInput.y) * speed;
        Vector3 james = (transform.up * horizontalInput.x) * turnSpeed;

        //Debug.Log(john + (transform.right * horizontalInput.x));

        characterController.Move(john * Time.deltaTime);

        transform.Rotate(transform.up, james.y * Time.deltaTime);
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
