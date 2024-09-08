using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerControles controls;
    public PlayerControles.GroundMoveActions groundMove;

    Vector2 horizontalMove;

    PlayerMove movement;

    void Awake()
    {
        controls = new PlayerControles();
        groundMove = controls.GroundMove;
        groundMove.HoreMove.performed += ctx => horizontalMove = ctx.ReadValue<Vector2>();


        movement = GetComponent<PlayerMove>();
        groundMove.Jump.performed += _u => movement.shouldJump();

        //groundMove.DriveMode.performed += _u => movement.SwitchInput();
    }

    void Update()
    {
        movement.ReciveInput(horizontalMove);
    }



    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
