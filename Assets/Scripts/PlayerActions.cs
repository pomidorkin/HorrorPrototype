using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float playerInteractDistance = 3f;
    bool active = false;
    PlyerInputActions plyerInputActions;
    RaycastHit hit;

    public delegate void InteractedAction(RaycastHit hit);
    public event InteractedAction OnInteractedAction;

    private void Awake()
    {
        plyerInputActions = new PlyerInputActions();
        plyerInputActions.Player.Enable();
        /// Player -> Action Map; Jump, Movement -> Actions; performed -> state
        plyerInputActions.Player.Interaction.performed += Interact;
    }

    private void Update()
    {
        active = Physics.Raycast(cam.position, cam.transform.TransformDirection(Vector3.forward), out hit, playerInteractDistance);

    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (active == true)
        {
            if (hit.transform.GetComponent<Collider>() != null)
            {
                OnInteractedAction(hit);
                Debug.Log("Interacting...");
            }
        }
    }


}
