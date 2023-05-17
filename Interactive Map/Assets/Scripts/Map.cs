using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private float _northGeoMaximum;
    [SerializeField] private float _southGeoMaximum;
    [SerializeField] private float _westGeoMaximum;
    [SerializeField] private float _eastGeoMaximum;

    [SerializeField] private Transform _northMaximum;
    [SerializeField] private Transform _southMaximum;
    [SerializeField] private Transform _westMaximum;
    [SerializeField] private Transform _eastMaximum;

    public Vector3 GetPosition(PinData data)
    {
        var xGeoDelta = _eastGeoMaximum - _westGeoMaximum;
        var yGeoDelta = _northGeoMaximum - _southGeoMaximum;

        var xDelta = _eastMaximum.position.x - _westMaximum.position.x;
        var yDelta = _northMaximum.position.y - _southMaximum.position.y;

        var yCurrent = data.Latitude - _southGeoMaximum;
        var xCurrent = data.Longitude - _westGeoMaximum;

        var y = _southMaximum.position.y + ((yCurrent / yGeoDelta) * yDelta);
        var x = _westMaximum.position.x + ((xCurrent / xGeoDelta) * xDelta);

        return new Vector3(x, y, 0);
    }
}
