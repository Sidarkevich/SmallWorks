using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Element
{
    protected override void Effect()
    {
        _score.IncreaseScore(1);
    }
}
