using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Element
{
    protected override void Effect()
    {
        _score.Loss();
    }
}
