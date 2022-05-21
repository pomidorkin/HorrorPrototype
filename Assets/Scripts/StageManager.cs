using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int currentStageId = 0;
    [SerializeField] Stage[] stages;
    [SerializeField] Progress progress;
    Stage currentStage;

    public class StangeChangedActionEventArgs : EventArgs
    {
        public Stage CurrentStage { get; set; }
    }

    public delegate void StageChangedAction(object source, StangeChangedActionEventArgs args); // Õ≈ “Œ, ¬Œ œ≈–¬€’ Õ≈ –¿¡Œ“¿≈“, ¬Œ ¬“Œ–€’, œŒ ¬»ƒ»ÃŒ—“», Õ”∆≈Õ Õ≈ ¬Œ»ƒ, ¿ ƒ–”√Œ… –≈“®–Õ “¿…œ
    public event StageChangedAction OnStageChangedAction;


    private void OnEnable()
    {
        StageGoal.OnActionChanged += GoToNextStage;
        OnStageChangedAction += _TEST;
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
        progress.currentStage = currentStage;
        OnStageChangedAction(this, new StangeChangedActionEventArgs() { CurrentStage = currentStage });
        OnStageChanged();
    }

    protected virtual void OnStageChanged()
    {
        if (OnStageChangedAction != null)
        {
            OnStageChangedAction(this, new StangeChangedActionEventArgs() { CurrentStage = currentStage });
        }
    }

    private void _TEST(object source, StangeChangedActionEventArgs args)
    {
        if (args.CurrentStage.currentStage == Stage.StageType.stageOne)
        {
            // Stage specific code
        }

    }
}
