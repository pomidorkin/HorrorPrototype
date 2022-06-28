using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomParent : MonoBehaviour
{
    [SerializeField] private Stage.StageType myStageType;
    [SerializeField] private StageManager stageManager;
    [SerializeField] private GameObject childRoom;
    [SerializeField] private DoorManager doorManager;
    private void OnEnable()
    {
        stageManager.OnStageChangedAction += CheckChangedStage;
        doorManager.OnDoorOpenedEvent += SetRoomPosition;
    }

    private void OnDisable()
    {
        stageManager.OnStageChangedAction -= CheckChangedStage;
        doorManager.OnDoorOpenedEvent -= SetRoomPosition;
    }

    private void SetRoomPosition(object source, DoorManager.DoorOpenedEventArgs args)
    {
        //childRoom.transform.position = args.PositinToSpawnTheRoom.position;
        gameObject.transform.position = args.PositinToSpawnTheRoom.position;
    }

    private void CheckChangedStage(object source, StageManager.StangeChangedActionEventArgs args)
    {
        if (args.CurrentStage.currentStage == myStageType)
        {
            childRoom.SetActive(true);
        }
        else
        {
            if (childRoom.activeInHierarchy)
            {
                childRoom.SetActive(false);
            }
        }
    }
}
