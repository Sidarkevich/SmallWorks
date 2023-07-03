using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _lossEvent;

    public void Loss()
    {
        _lossEvent?.Invoke();
    }
}
