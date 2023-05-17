using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private Transform _pinParent;
    [SerializeField] private Pin[] _pins;
    [SerializeField] private PinData[] _testData;

    private void Start()
    {
        /*foreach (var data in _testData)
        {
            var pin = Instantiate(_pins[data.TypeId()], _pinParent.transform);
            pin.transform.position = _map.GetPosition(data);
        }*/
    }
}
