using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spot : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    private Color32 _color;
    private string _title;

    public void Setup(Color32 color)
    {
        _color = color;
        _image.color = _color;
    }

    public void Setup(string title)
    {
        _title = title;
        _text.text = _title;
    }
}
