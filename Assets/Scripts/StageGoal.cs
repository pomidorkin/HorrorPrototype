using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StageGoal
{
    public Stage stage;
    public int requiredAmount;
    public int currentAmount;
    public bool wasInteracted;

    public delegate void ReachGoalActiom();
    public static event ReachGoalActiom OnActionChanged;


    public void CheckIfGoalIsReached()
    {
        // HERE WE HAVE TO DEFINE CONDITIONS THAT WOULD BE NEEDED TO REACH THE GOAL

        if (stage.currentStage == (Stage.StageType) 0)
        {
            if (IsGoalReached())
            {
                currentAmount = 0;
                wasInteracted = false;
                ReachTheGoal();
            }
            Debug.Log("YES! STAGE ONE " + stage.currentStage);
        } else if (stage.currentStage == (Stage.StageType)1)
        {
            if (wasInteracted)
            {
                currentAmount = 0;
                wasInteracted = false;
                ReachTheGoal();
            }
            Debug.Log("YES! STAGE TWO " + stage.currentStage);
        } else if (stage.currentStage == (Stage.StageType)2)
        {
            Debug.Log("YES! STAGE THREE " + stage.currentStage);
        }
    }

    public bool IsGoalReached()
    {
        return currentAmount >= requiredAmount;
    }

    public void ReachTheGoal()
    {
        OnActionChanged();
    }

    public void AddCurrentAmount()
    {
        currentAmount++;
    }

    public void MarkAsInteracted()
    {
        wasInteracted = true;
    }
}
