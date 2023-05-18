using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    [SerializeField] private ObjectPanel _panel;

    private MapObject _currentFocus;

    public void ChangeFocus(MapObject nextFocus)
    {
        _panel.Setup(nextFocus);
    }
}
