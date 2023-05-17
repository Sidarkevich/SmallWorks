using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PinData : ScriptableObject
{
    public float Latitude => _latitude;
    public float Longitude => _longitude;
    public float Square => _square;

    [SerializeField] private string _name;
    [SerializeField] private float _latitude;
    [SerializeField] private float _longitude;
    [SerializeField] private float _square;

    public abstract string TypeName();
    public abstract int TypeId();
}
