using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _minSpeed = 1.0f;
    
    public float SpeedValue => _speedValue;
    
    private float _speedValue;

    public void ChangeSpeed(float newValue)
    {
        _speedValue = Mathf.Max(newValue, _minSpeed);
    }

    public void ResetSpeed()
    {
        _speedValue = _startSpeed;
    }
}
