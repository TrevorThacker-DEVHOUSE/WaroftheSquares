using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Actions/Increase")]
public class A_Increase : Action
{
    public float rate = 5;
    public override float DoAction(Cell cell, TargetSelect inputTargets, TargetSelect outputTargets)
    {
        List<Cell> targets = outputTargets.GetTargets(cell.nearby);
        targets = targets.Where(x => x.command.action != this).ToList();
        if (targets.Count == 0) return 0f;
        float actualRate = Mathf.Clamp(rate, -100f, 100f) / targets.Count;
        foreach (Cell c in targets)
        {
            c.Power += actualRate;
            //Debug.Log($"{c} power: {c.Power}");
        }
        return rate / 2f;
    }
}
