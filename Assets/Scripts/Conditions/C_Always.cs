using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Always")]
public class C_Always : Condition
{
    public override bool Check(Cell cell)
    {
        return cell.Power >= 0;
    }
}
