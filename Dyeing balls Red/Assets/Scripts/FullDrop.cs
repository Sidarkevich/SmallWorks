using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullDrop : Drop
{
    public override void UseEffect(Ball ball)
    {
        Debug.Log("Buff!");
    }
}
