using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LandscapeData")]
public class LandscapeData : PinData
{
    public override int TypeId()
    {
        return 0;
    }

    public override string TypeName()
    {
        return "Ландшафтный";
    }
}
