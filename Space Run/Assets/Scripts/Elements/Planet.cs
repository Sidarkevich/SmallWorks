using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Element
{
    [SerializeField] private int _scoreValue;

    protected override void Effect()
    {
        _score.IncreaseScore(_scoreValue);
    }
}
