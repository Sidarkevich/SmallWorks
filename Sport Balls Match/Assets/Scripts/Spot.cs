using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spot : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Setup(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
