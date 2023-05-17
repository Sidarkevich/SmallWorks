using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LandscapeData")]
public class LandscapeData : PinData
{
    public override string TypeName()
    {
        return "Ландшафтный";
    }
}
