using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
    public UnityEvent<bool> ValueChangedEvent;

    [SerializeField] private TMP_Text _OnText;
    [SerializeField] private TMP_Text _OffText;

    private bool _isOn = true;

    public void Clicked()
    {
        _isOn = !_isOn;
        Setup();

        ValueChangedEvent?.Invoke(!_isOn);
    }

    public void SetValue(bool value)
    {
        _isOn = !value;
        Setup();
    }

    public void ChangeValue()
    {
        _isOn = !_isOn;
        Setup();
    }

    private void Setup()
    {
        _OnText.gameObject.SetActive(_isOn);
        _OffText.gameObject.SetActive(!_isOn);
    }
}