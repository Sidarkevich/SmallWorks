using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _increaseValue;

    public float CurrentSpeed => _currentSpeed;

    private float _currentSpeed;

    public void Reset()
    {
        _currentSpeed = _startSpeed;
    }

    public void IncreaseSpeed()
    {
        _currentSpeed += _increaseValue;
    }
}
