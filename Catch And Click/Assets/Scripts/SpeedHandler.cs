using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _increaseValue;

    public float Speed => _currentSpeed;

    private float _currentSpeed;

    public void Increase()
    {
        _currentSpeed += _increaseValue;
    }

    public void Reset()
    {
        _currentSpeed = _startSpeed;
    }

    private void Awake()
    {
        Reset();
    }
}
