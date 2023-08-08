using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _speedIncrease;

    public float Speed => _speed;

    private float _speed;

    public void Increase(float value)
    {
        _speed += value * _speedIncrease;
    }

    public void Reset()
    {
        _speed = _startSpeed;
    }
}
