using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : Singleton<Board>
{
    public Vector2Int boardDimensions;
    private Cell[,] board;

    [SerializeField]
    private UnityEngine.UI.GridLayoutGroup boardPanel;
    [SerializeField]
    private Cell defaultCell;

    private void Start()
    {
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        board = new Cell[boardDimensions.x, boardDimensions.y];
        boardPanel.constraintCount = boardDimensions.y;
        boardPanel.cellSize = new Vector2(
            Screen.height * 1f / (boardDimensions.y) - 2, 
            Screen.height * 1f / (boardDimensions.y) - 2);

        for (int i = 0; i <= board.GetUpperBound(0); i++)
        {
            for(int j = 0; j <= board.GetUpperBound(1); j++)
            {
                Cell cell = board[i,j] = Instantiate(defaultCell);
                cell.name = $"Cell({i},{j})";
                cell.transform.SetParent(boardPanel.transform, false);
                //cell.rect.anchoredPosition = new Vector2((i - boardDimensions.x / 2f) * cell.rect.rect.width, (j - boardDimensions.y / 2f) * cell.rect.rect.height);
            }
        }

        for (int i = 0; i <= board.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= board.GetUpperBound(1); j++)
            {
                Cell cell = board[i, j];
                for (int x = -1; x <= 1; x++)
                    for (int y = -1; y <= 1; y++)
                    {
                        if (i + x < 0 || i + x > board.GetUpperBound(0) || j + y < 0 || j + y > board.GetUpperBound(1))
                            cell.nearby[1 + x, 1 + y] = null;
                        else
                            cell.nearby[1 + x, 1 + y] = board[i+x,j+y];
                    }
            }
        }
    }

    private void FixedUpdate()
    {
        DoBoardLogic();
    }

    private void DoBoardLogic()
    {
        for (int i = 0; i <= board.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= board.GetUpperBound(1); j++)
            {
                board[i, j].command.DoCommand(board[i, j]);
            }
        }
    }
}
