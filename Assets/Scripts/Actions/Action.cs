using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract float DoAction(Cell cell, TargetSelect inputTargets, TargetSelect outputTargets);
}
