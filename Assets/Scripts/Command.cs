using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Command
{
    public Condition condition;
    public Action action;
    public TargetSelect inputTargets;
    public TargetSelect outputTargets;
    public void DoCommand(Cell cell)
    {
        if (condition == null || action == null || !condition.Check(cell)) return;
        float cost = action.DoAction(cell, inputTargets, outputTargets);
        cell.Power -= cost;
    }
}
