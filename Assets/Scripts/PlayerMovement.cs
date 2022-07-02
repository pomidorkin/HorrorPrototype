using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 1f;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    PlyerInputActions plyerInputActions;

    Vector3 velocity;
    bool isGrounded;

    private void Awake()
    {
        plyerInputActions = new PlyerInputActions();
        plyerInputActions.Player.Enable();
        /// Player -> Action Map; Jump, Movement -> Actions; performed -> state
        plyerInputActions.Player.Jump.performed += Jump;
    }

    void FixedUpdate()
    {
        // Projecting a sphere that checks if we are grounded

        /*isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);*/

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 inputVector = plyerInputActions.Player.Movement.ReadValue<Vector2>();
        //controller.Move(new Vector3(inputVector.x, 0, inputVector.y) * speed * Time.deltaTime);
        float x = inputVector.x;
        float z = inputVector.y;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    // NEW INPUT SYSTEM TEST

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
