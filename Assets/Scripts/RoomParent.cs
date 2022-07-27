using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomParent : MonoBehaviour
{
    [SerializeField] public Stage.StageType myStageType;
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
        if (myStageType == stageManager.currentStage.currentStage)
        {
            gameObject.transform.position = args.PositinToSpawnTheRoom.position;
        }
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

    public void SetChildActive(bool active)
    {
        childRoom.gameObject.SetActive(active);
    }
}
