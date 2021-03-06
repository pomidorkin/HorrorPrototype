using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Stage", fileName = "Stage")]
public class Stage : ScriptableObject
{
    public StageType currentStage;
    public GoalType goalType;
    public StageLocationType stageLocationType;
    public StageGoal stageGoal;
    public enum StageType { stageOne, stageTwo, stageTree, stageFour, stageFive, stageSix, stageSeven };
    public enum GoalType { amountGoal, interactGoal };
    public enum StageLocationType { room, corridor }
}
