using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Increase")]
public class A_Increase : Action
{
    public float rate = 5;
    public override void DoAction(Cell cell, TargetSelect inputTargets, TargetSelect outputTargets)
    {
        List<Cell> targets = outputTargets.GetTargets(cell.nearby);
        float actualRate = Mathf.Clamp(rate, -100f, 100f) / targets.Count;
        foreach (Cell c in targets)
        {
            c.Power += actualRate;
            //Debug.Log($"{c} power: {(int)c.Power}");
        }
    }
}
