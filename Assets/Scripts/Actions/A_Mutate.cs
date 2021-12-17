using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[CreateAssetMenu(menuName = "Actions/Mutate")]
public class A_Mutate : Action
{
    public float cost = 10f;
    public override float DoAction(Cell cell, TargetSelect inputTargets, TargetSelect outputTargets)
    {
        List<Cell> targets = outputTargets.GetTargets(cell.nearby);
        foreach (Cell c in targets)
        {
            foreach(PropertyInfo p in c.command.action.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {

            }
        }
        return cost;
    }
}
