using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Image _image;

    public int ColorIndex => _colorIndex;

    private int _colorIndex;

    public void ChangeColor(int index)
    {
        _colorIndex = index;
        _image.sprite = _sprites[_colorIndex];
    }

    public void SetRandomColor()
    {
        _colorIndex = Random.Range(0, _sprites.Count);
        _image.sprite = _sprites[_colorIndex];
    }
}
