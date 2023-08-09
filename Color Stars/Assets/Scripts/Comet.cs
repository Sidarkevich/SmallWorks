using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comet : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private ColorHandler _colors;

    public Sprite CurrentSprite => _image.sprite;

    public void ChangeColor()
    {
        _image.sprite = _colors.GetAnotherRandom(_image.sprite);
    }

    private void OnEnable()
    {
        _image.sprite = _colors.GetRandom();
    }
}
