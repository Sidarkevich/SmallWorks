using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHandler : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _fillSpeed;
    [SerializeField] private ScoreHandler _scoreHandler;

    private float _value;

    public void Reset()
    {
        _value = 0;
    }

    private void FixedUpdate()
    {
        _value += _fillSpeed;

        if (_value >= 1.0f)
        {
            _value = 0;
        }

        _image.fillAmount = _value;
    }
}
