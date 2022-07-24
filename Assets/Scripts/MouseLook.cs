using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 0.1f;
    [SerializeField] Transform playerBody;
    PlyerInputActions plyerInputActions;
    float xRotation = 0f;

    // NIPS TEST
    private Vector2 MouseMoveInput;

    // NIPS TEST
    private void Awake()
    {
        plyerInputActions = new PlyerInputActions();
        plyerInputActions.Player.Enable();
        plyerInputActions.Player.Look.performed += Look;
    }

    // NIPS TEST
    float xRot;
    private void Look(InputAction.CallbackContext obj)
    {
        Vector2 NonNormalizedDelta = MouseMoveInput * .5f * .1f;

        xRot -= NonNormalizedDelta.y * mouseSensitivity;

        playerBody.Rotate(0f, NonNormalizedDelta.x * mouseSensitivity, 0f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    void Update()
    {
        MouseMoveInput = plyerInputActions.Player.Look.ReadValue<Vector2>();
    }

    // end NIPS TEST
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // NIPS TEST

    }

    // Update is called once per frame
   /* void Update()
    {
        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity * Time.deltaTime;
        float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }*/
}
