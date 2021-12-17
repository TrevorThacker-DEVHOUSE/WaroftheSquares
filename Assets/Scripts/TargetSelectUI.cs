using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSelectUI : MonoBehaviour
{
    [SerializeField]
    private Toggle[] toggles = new Toggle[9];
    public TargetSelect targets;

    private void Start()
    {
        toggles[0].onValueChanged.AddListener(b => UpdateTargets(b, 0, 0));
        toggles[1].onValueChanged.AddListener(b => UpdateTargets(b, 0, 1));
        toggles[2].onValueChanged.AddListener(b => UpdateTargets(b, 0, 2));
        toggles[3].onValueChanged.AddListener(b => UpdateTargets(b, 1, 0));
        toggles[4].onValueChanged.AddListener(b => UpdateTargets(b, 1, 1));
        toggles[5].onValueChanged.AddListener(b => UpdateTargets(b, 1, 2));
        toggles[6].onValueChanged.AddListener(b => UpdateTargets(b, 2, 0));
        toggles[7].onValueChanged.AddListener(b => UpdateTargets(b, 2, 1));
        toggles[8].onValueChanged.AddListener(b => UpdateTargets(b, 2, 2));
    }

    private void UpdateTargets(bool b, int x, int y)
    {
        if (!UIManager.Instance.SelectedCell) return;
        targets.targets[x, y] = b;
        Debug.Log($"at {x},{y}: {targets.targets[x, y]}");
        UIManager.Instance.SelectedCell.command.outputTargets = targets;
    }
}

[System.Serializable]
public class TargetSelect
{
    public bool[,] targets = new bool[3, 3];
    public int maximumTargets = 9;
    public bool requireMaxPower = true;

    public bool Match(Cell[,] cells)
    {
        bool match = true;
        for (int i = 0; i <= cells.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= cells.GetUpperBound(1); j++)
            {
                if(targets[i, j])
                    if (requireMaxPower)
                    {
                        if (cells[i, j].Power != 100)
                            match = false;
                    }
                    else
                    {
                        if (cells[i, j].Power <= 0)
                            match = false;
                    }
            }
        }
        return match;
    }

    public List<Cell> GetTargets(Cell[,] cells)
    {
        List<Cell> t = new List<Cell>();
        for (int i = 0; i <= cells.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= cells.GetUpperBound(1); j++)
            {
                if (targets[i, j] && cells[i, j] != null)
                    t.Add(cells[i, j]);
            }
        }
        return t;
    }
}