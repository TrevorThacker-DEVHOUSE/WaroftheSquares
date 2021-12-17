using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Copy")]
public class A_Copy : Action
{

    public override float DoAction(Cell cell, TargetSelect inputTargets, TargetSelect outputTargets)
    {
        return 0;
    }
}
