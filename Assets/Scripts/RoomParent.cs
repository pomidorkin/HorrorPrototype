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
        Debug.Log("SetRoomPosition(); " + "myStageType: " + myStageType + "stageManager.currentStage.currentStage: " + stageManager.currentStage.currentStage);
    }

    private void CheckChangedStage(object source, StageManager.StangeChangedActionEventArgs args)
    {
        SpawnRoom(args.CurrentStage);
        Debug.Log("CheckChangedStage();");
    }

    public void SpawnRoom(Stage stage)
    {
        if (stage.currentStage == myStageType)
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

        Debug.Log("SpawnRoom(stage);");
    }

    public void SpawnRoom(bool active)
    {
        childRoom.gameObject.SetActive(active);
        Debug.Log("SpawnRoom(" + active + ");");
    }
}
