using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ToggleButton : MonoBehaviour
{
    public UnityEvent<bool> ValueChangedEvent;

    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _OnText;
    [SerializeField] private TMP_Text _OffText;

    private bool _isOn = true;

    public void Clicked()
    {
        _isOn = !_isOn;
        Setup();

        ValueChangedEvent?.Invoke(_isOn);
    }

    public void ChangeValue(bool value)
    {
        _isOn = value;
        Setup();
    }

    private void Setup()
    {
        _button.targetGraphic = (_isOn ? _OnText : _OffText);

        _OnText.gameObject.SetActive(_isOn);
        _OffText.gameObject.SetActive(!_isOn);
    }
}
