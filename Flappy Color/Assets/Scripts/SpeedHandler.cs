using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    
    public float SpeedValue => _speedValue;

    private float _speedValue;

    public void Increase(float value)
    {
        if (value > 0)
        {
            _speedValue += value;
        }
    }

    public void Reset()
    {
        _speedValue = _startSpeed;
    }
}
