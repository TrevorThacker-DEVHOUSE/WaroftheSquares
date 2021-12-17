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
        if (condition == null || !condition.Check(cell)) return;
        action?.DoAction(cell, inputTargets, outputTargets);
    }
}
