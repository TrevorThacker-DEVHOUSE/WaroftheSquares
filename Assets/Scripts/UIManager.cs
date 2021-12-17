using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI power;
    [SerializeField]
    private TextMeshProUGUI condition;
    [SerializeField]
    private TextMeshProUGUI action;
    [SerializeField]
    private TargetSelectUI inputs;
    [SerializeField]
    private TargetSelectUI outputs;
    [SerializeField]
    private TextMeshProUGUI conditionList;
    [SerializeField]
    private TextMeshProUGUI actionList;

    [SerializeField]
    private RawImage selectedBoarder;
    [SerializeField]
    private Action[] actions;
    [SerializeField]
    private Condition[] conditions;

    public bool lookForInput = false;
    public bool LookForInput { set { lookForInput = value; } }
    public bool setAction = false;
    public bool SetAction { set { setAction = value; } }
    private Cell _selectedCell;
    public Cell SelectedCell
    {
        get
        {
            return _selectedCell;
        }
        set
        {
            _selectedCell = value;
            if (value == null)
            {
                selectedBoarder.gameObject.SetActive(false);
            }
            else
            {
                selectedBoarder.gameObject.SetActive(true);
                //selectedBoarder.transform.parent = value.rect.parent;
                selectedBoarder.rectTransform.sizeDelta = value.rect.sizeDelta;
                selectedBoarder.rectTransform.anchoredPosition = value.rect.anchoredPosition;
                selectedBoarder.transform.SetAsLastSibling();
            }
            UpdateUI();
        }
    }

    private void Start()
    {
        selectedBoarder.rectTransform.sizeDelta = new Vector2(Screen.height / (Board.Instance.boardDimensions.y - 1), Screen.height / (Board.Instance.boardDimensions.y - 1));
    }

    private void Update()
    {
        if (lookForInput && Input.anyKeyDown)
        {
            int num = -1;
            if (Input.GetKeyDown(KeyCode.Alpha1)) num = 1;
            if (Input.GetKeyDown(KeyCode.Alpha2)) num = 2;
            if (Input.GetKeyDown(KeyCode.Alpha3)) num = 3;
            if (Input.GetKeyDown(KeyCode.Alpha4)) num = 4;
            if (Input.GetKeyDown(KeyCode.Alpha5)) num = 5;
            if (Input.GetKeyDown(KeyCode.Alpha6)) num = 6;
            if (Input.GetKeyDown(KeyCode.Alpha6)) num = 6;
            if(_selectedCell != null)
                switch (num)
                {
                    case 1:
                        if (setAction)
                            _selectedCell.command.action = actions[0];
                        else
                            _selectedCell.command.condition = conditions[0];
                        break;
                    case 2:
                        if (setAction)
                            _selectedCell.command.action = actions[1];
                        else
                            _selectedCell.command.condition = conditions[1];
                        break;
                    case 3:
                        if (setAction)
                            _selectedCell.command.action = actions[2];
                        else
                            _selectedCell.command.condition = conditions[2];
                        break;
                    case 4:
                        if (setAction)
                            _selectedCell.command.action = actions[3];
                        else
                            _selectedCell.command.condition = conditions[3];
                        break;
                    case 5:
                        if (setAction)
                            _selectedCell.command.action = actions[4];
                        else
                            _selectedCell.command.condition = conditions[4];
                        break;
                    case 6:
                        if (setAction)
                            _selectedCell.command.action = actions[5];
                        else
                            _selectedCell.command.condition = conditions[5];
                        break;
                }
            conditionList.gameObject.SetActive(false);
            actionList.gameObject.SetActive(false);
            setAction = false;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if(_selectedCell != null)
        {
            power.text = $"Power: {(int)_selectedCell.Power}%";
            if(_selectedCell.command.condition)
                condition.text = $"{_selectedCell.command.condition.name}";
            if (_selectedCell.command.action)
                action.text = $"{_selectedCell.command.action.name}";
            inputs.UpdateUI(_selectedCell.command.inputTargets);
            outputs.UpdateUI(_selectedCell.command.outputTargets);
        }
        else
        {
            power.gameObject.SetActive(false);
        }
    }
}
