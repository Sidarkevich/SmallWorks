using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Element
{
    [SerializeField] private float _speedCoefficient;

    protected override void Effect()
    {
        _speed.ChangeSpeed(_speed.SpeedValue * _speedCoefficient);
    }
}
