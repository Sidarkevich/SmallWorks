using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PinData")]
public class PinData : ScriptableObject
{
    public float Latitude => _latitude;
    public float Longitude => _longitude;

    [SerializeField] private float _latitude;
    [SerializeField] private float _longitude;
}
