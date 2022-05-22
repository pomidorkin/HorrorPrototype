using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOne : MonoBehaviour
{
    [SerializeField] StageManager stageManager;
    private void OnEnable()
    {
        Debug.Log("Hey, I am running code from ROOM ONE");
        // Stage-specific code
    }

    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            //GoToNextStage();
            stageManager.currentStage.stageGoal.MarkAsInteracted();
            stageManager.currentStage.stageGoal.CheckIfGoalIsReached();
        }
    }


}
