using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Nearby")]
public class C_Nearby : Condition
{
    public TargetSelect targets;
    public override bool Check(Cell cell)
    {
        return targets.Match(cell.nearby);
    }
}
