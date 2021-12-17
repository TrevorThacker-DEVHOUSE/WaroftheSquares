using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private RawImage selectedBoarder;

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

    private void UpdateUI()
    {
        if(_selectedCell == null)
        {

        }
    }
}
