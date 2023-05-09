using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullDrop : Drop
{
    [SerializeField] private int _buffValue;

    public override void UseEffect(Ball ball)
    {
        ball.GetBuff(_buffValue);
    }
}
