using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Element
{
    [SerializeField] private float _speedDecrease;

    protected override void Effect()
    {
        SpeedHandler.ChangeSpeed(SpeedHandler.SpeedValue - _speedDecrease);
    }
}
