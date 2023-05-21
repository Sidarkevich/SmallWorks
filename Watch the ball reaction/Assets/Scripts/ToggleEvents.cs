using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleEvents : MonoBehaviour
{
    public UnityEvent<bool> ToggleValueAfterLoadEvent;

    private bool _loading;

    private void Awake()
    {
        _loading = true;
    }

    private void Start()
    {
        _loading = false;
    }

    public void OnToggleValueChanged(bool value)
    {
        if (_loading)
        {
            return;
        }

        ToggleValueAfterLoadEvent?.Invoke(value);
    }
}
