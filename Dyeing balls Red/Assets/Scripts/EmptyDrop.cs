using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyDrop : Drop
{
    [SerializeField] private int _damageValue;

    public override void UseEffect(Ball ball)
    {
        ball.GetHit(_damageValue);
    }
}
