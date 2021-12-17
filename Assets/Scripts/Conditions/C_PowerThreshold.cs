using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Power Threshold")]
public class C_PowerThreshold : Condition
{
    public int power = 100;
    public override bool Check(Cell cell)
    {
        return cell.Power == Mathf.Clamp(power, -100,100);
    }
}