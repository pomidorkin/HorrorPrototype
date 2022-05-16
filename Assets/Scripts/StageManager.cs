using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int currentStageId = 0;
    [SerializeField] Stage[] stages;
    Stage currentStage;
    private void OnEnable()
    {
        StageGoal.OnActionChanged += GoToNextStage;
    }

    private void OnDisable()
    {
        StageGoal.OnActionChanged -= GoToNextStage;
    }
    private void Start()
    {
        currentStage = stages[currentStageId];
    }

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            //GoToNextStage();
            currentStage.stageGoal.CheckIfGoalIsReached();
        }

        if (Input.GetKeyDown("y"))
        {
            //GoToNextStage();
            currentStage.stageGoal.AddCurrentAmount();
            currentStage.stageGoal.CheckIfGoalIsReached();
        }

        if (Input.GetKeyDown("z"))
        {
            //GoToNextStage();
            currentStage.stageGoal.MarkAsInteracted();
            currentStage.stageGoal.CheckIfGoalIsReached();
        }

    }

    private void GoToNextStage()
    {
        currentStageId++;
        currentStage = stages[currentStageId];
    }
}
