using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
    public UnityEvent<bool> ValueChangedEvent;

    [SerializeField] private Image _OffImage;
    [SerializeField] private Button _button;

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
        _OffImage.gameObject.SetActive(!_isOn);
    }
}