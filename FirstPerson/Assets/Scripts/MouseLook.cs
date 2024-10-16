using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    PlayerControles playerControles;

    Vector2 mouseInput;

    //Horizontal
    [SerializeField] float horizontalSens = 8;
    float mouseX;

    //Vertical
    [SerializeField] float verticalSens = 0.5f;
    float mouseY;
    [SerializeField] Transform mainCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    public Vector2 mouseDelta;

    PlayerMove player;

    // Start is called before the first frame update
    void Start()
    {
        playerControles = GetComponent<InputManager>().controls;
        playerControles.GroundMove.LookX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        playerControles.GroundMove.LookY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.inputState == InputState.PlayerInput)
        {


            mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            mouseDelta = Mouse.current.delta.ReadValue();

            //Horizontal
            mouseX = mouseInput.x * horizontalSens;
            transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

            //Vertical
            mouseY = mouseInput.y * verticalSens;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

            Vector3 targetRotation = mainCamera.eulerAngles;

            targetRotation.x = xRotation;

            mainCamera.eulerAngles = targetRotation;
        }

    }
}
