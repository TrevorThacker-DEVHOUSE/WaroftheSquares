using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public RawImage image;
    public RectTransform rect;
    public Command command;
    public Cell[,] nearby = new Cell[3,3];

    private float _color = 0.5f;
    public float Colour
    {
        set
        {
            _color = Mathf.Clamp01(value);
            UpdateImage();
        }

        get
        {
            return _color;
        }
    }
    public float Power
    {
        get
        {
            float percent = ((_color - 0.5f) * 2 * 100);
            return (Player.Instance.PlayerTeam == Team.White ? 1f : -1f) * percent; 
        }
        set
        {
            Colour = (Player.Instance.PlayerTeam == Team.White ? 1f : -1f) * value / 100f * 0.5f + 0.5f;
        }
    }

    private void UpdateImage()
    {
        image.color = new Color(_color, _color, _color);
    }

    private void Start()
    {
        UpdateImage();
    }
}
