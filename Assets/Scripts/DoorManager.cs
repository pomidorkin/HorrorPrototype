using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorManager : MonoBehaviour
{
    public class DoorOpenedEventArgs : EventArgs
    {
        public Transform PositinToSpawnTheRoom { get; set; }
    }

    public delegate void DoorOpenedEvent(object source, DoorOpenedEventArgs args);
    public event DoorOpenedEvent OnDoorOpenedEvent;

    public void DoorOpened(Transform transform)
    {
        OnDoorOpenedEvent(this, new DoorOpenedEventArgs { PositinToSpawnTheRoom = transform });
    }
}
