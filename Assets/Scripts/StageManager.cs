using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int currentStageId = 0;
    [SerializeField] Stage[] stages;
    [SerializeField] Progress progress;
    public Stage currentStage;

    public class StangeChangedActionEventArgs : EventArgs
    {
        public Stage CurrentStage { get; set; }
    }

    public delegate void StageChangedAction(object source, StangeChangedActionEventArgs args); // ме рн, бн оепбшу ме пюанрюер, бн брнпшу, он бхдхлнярх, мсфем ме бнхд, ю дпсцни пер╗пм рюио
    public event StageChangedAction OnStageChangedAction;


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
        if (!progress.currentStage)
        {
            progress.currentStage = currentStage;
        }
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

        /*if (Input.GetKeyDown("z"))
        {
            //GoToNextStage();
            currentStage.stageGoal.MarkAsInteracted();
            currentStage.stageGoal.CheckIfGoalIsReached();
        }*/

    }

    private void GoToNextStage()
    {
        currentStageId++;
        currentStage = stages[currentStageId];
        progress.currentStage = currentStage;
        OnStageChangedAction(this, new StangeChangedActionEventArgs() { CurrentStage = currentStage });
    }

}
