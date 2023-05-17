using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private PinData _data;
    [SerializeField] private Map _map;

    void Start()
    {
        transform.position = _map.GetPosition(_data);    
    }
}
