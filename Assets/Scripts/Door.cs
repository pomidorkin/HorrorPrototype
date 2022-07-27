using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] Transform roomPosition;
    [SerializeField] DoorManager doorManager;

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
    }

    public void OpenDoor(RaycastHit hit)
    {
        if (hit.transform == this.transform)
        {
            Debug.Log("I am the door and I am being opened...");
            doorManager.DoorOpened(roomPosition);
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
}
