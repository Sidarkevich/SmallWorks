using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BiologicalData")]
public class BiologicalData : PinData
{
    public override int TypeId()
    {
        return 1;
    }

    public override string TypeName()
    {
        return "Биологический";
    }
}
