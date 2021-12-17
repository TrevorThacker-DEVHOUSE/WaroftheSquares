using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[CreateAssetMenu(menuName = "Actions/Mutate")]
public class A_Mutate : Action
{
    public override void DoAction(Cell cell, TargetSelect inputTargets, TargetSelect outputTargets)
    {
        List<Cell> targets = outputTargets.GetTargets(cell.nearby);
        foreach (Cell c in targets)
        {
            foreach(PropertyInfo p in c.command.action.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {

            }
        }
    }
}
