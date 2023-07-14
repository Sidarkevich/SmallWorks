using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Element
{
    protected override void Effect()
    {
        _pool.DeactivateAllType(this.GetType());
    }
}
