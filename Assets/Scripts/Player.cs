using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum Team { Gray, White, Black }
public class Player : Singleton<Player>
{
    public Team PlayerTeam;

    [SerializeField]
    private GraphicRaycaster raycaster;
    [SerializeField]
    private EventSystem eventSystem;
    
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClicked();
        }
    }

    private void CheckClicked()
    {
        PointerEventData data = new PointerEventData(eventSystem);
        data.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        bool selectedSame = false;
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Cell>())
            {
                if(UIManager.Instance.SelectedCell == result.gameObject.GetComponent<Cell>())
                    selectedSame = true;
                UIManager.Instance.SelectedCell = result.gameObject.GetComponent<Cell>();
            }
        }
        if (selectedSame)
            UIManager.Instance.SelectedCell = null;
    }
}
