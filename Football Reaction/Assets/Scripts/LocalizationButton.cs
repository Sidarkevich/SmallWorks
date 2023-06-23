using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LocalizationButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _selectedImage;

    private Color _disabledColor = Color.black;
    private Color _activeColor = Color.white;

    public void ChangeState(bool state)
    {
        _selectedImage.enabled = state;
        _text.color = state? _disabledColor : _activeColor;
    }
}
