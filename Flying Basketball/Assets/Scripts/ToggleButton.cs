using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
    public UnityEvent<bool> ValueChangedEvent;

    [SerializeField] private Button _button;
    [SerializeField] private Image _OnImage;
    [SerializeField] private Image _OffImage;

    private bool _isOn = true;

    public void Clicked()
    {
        _isOn = !_isOn;
        Setup();

        ValueChangedEvent?.Invoke(_isOn);
    }

    public void SetValue(bool value)
    {
        _isOn = value;
        Setup();
    }

    public void ChangeValue()
    {
        _isOn = !_isOn;
        Setup();
    }

    private void Setup()
    {
        _button.targetGraphic = (_isOn ? _OnImage : _OffImage);

        _OnImage.gameObject.SetActive(_isOn);
        _OffImage.gameObject.SetActive(!_isOn);
    }
}