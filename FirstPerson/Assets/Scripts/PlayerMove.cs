using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Physics = RotaryHeart.Lib.PhysicsExtension.Physics;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10.0f;

    Vector2 horizontalInput;

    [SerializeField] float gravity = -20.0f;
    Vector3 VertivalVolocity;

    [SerializeField] LayerMask groundLayer;
    bool isGrounded = false;

    bool isJumping = false;
    [SerializeField] float jumpHeight = 3.5f;

    void Update()
    {
        Vector3 john = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        characterController.Move(john * Time.deltaTime);
        
        VertivalVolocity.y += gravity * Time.deltaTime;

        characterController.Move(VertivalVolocity * Time.deltaTime);
        CheckGround();
        if (isJumping)
        {
            jump();
        }

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

        Debug.Log(isGrounded);

        if (isGrounded && VertivalVolocity.y < 0)
        {
            VertivalVolocity.y = 0;
        }
    }

    void CarMove() 
    {

    }

    void PlayMove()
    {

    }

    public void ReciveInput(Vector3 _horizontalInput) 
    {
        horizontalInput = _horizontalInput;
    }
}
