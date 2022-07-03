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
    // NEW INPUT SYSTEM TEST
    private void Awake()
    {
        plyerInputActions = new PlyerInputActions();
        plyerInputActions.Player.Enable();
        /// Player -> Action Map; Jump, Movement -> Actions; performed -> state
        plyerInputActions.Player.Jump.performed += Jump;
    }

    void FixedUpdate()
    {
        // Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);

        // Moving
        Vector2 inputVector = plyerInputActions.Player.Movement.ReadValue<Vector2>();
        float x = inputVector.x;
        float z = inputVector.y;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
    }
}
