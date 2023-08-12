using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    public float CurrentSpeed => _currentSpeed;

    private float _currentSpeed;

    public void Reset()
    {
        _currentSpeed = _startSpeed;
    }
}
