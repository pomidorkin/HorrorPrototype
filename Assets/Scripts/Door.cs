using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] bool isRightDoor = false;
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] Transform roomPosition;
    [SerializeField] DoorManager doorManager;
    string interactionText = "Open Door";

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
    }

    public void OpenDoor(RaycastHit hit)
    {
        // TODO: Toggle the boolean field (Open/Closed)
        if (hit.transform == this.transform)
        {
            Debug.Log("I am the door and I am being opened...");
            doorManager.DoorOpened(roomPosition, isRightDoor);
        }
    }

    private void OnEnable()
    {
        playerActions.OnInteractedAction += OpenDoor;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= OpenDoor;
    }

    public string GetInteractionText()
    {
        // TODO: Return different text depending on the state of the door (Open/Closed)
        return interactionText;
    }
}
