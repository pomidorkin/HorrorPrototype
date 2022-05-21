using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomParent : MonoBehaviour
{
    [SerializeField] private Stage.StageType myStageType;
    [SerializeField] private StageManager stageManager;
    [SerializeField] private GameObject childRoom;
    private void OnEnable()
    {
        stageManager.OnStageChangedAction += CheckChangedStage;
    }

    private void OnDisable()
    {
        stageManager.OnStageChangedAction -= CheckChangedStage;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
