using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    [SerializeField] Transform roomPosition;
    [SerializeField] DoorManager doorManager;

    [SerializeField] public bool TEST_OPEN_DOOR; // DELETE (USED ONLY FOR TESTING)

    public void OpenDoor()
    {
        doorManager.DoorOpened(roomPosition);
    }

    private void Update() // DELETE (USED ONLY FOR TESTING)
    {
        if (TEST_OPEN_DOOR)
        {
            TEST_OPEN_DOOR = false;
            OpenDoor();
        }
    }
}
