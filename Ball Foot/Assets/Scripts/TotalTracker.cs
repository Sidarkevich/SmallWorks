using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TotalTracker : MonoBehaviour
{
    [SerializeField] private UnityEvent _moreEqualEvent;
    [SerializeField] private UnityEvent _lessEvent;

    [SerializeField] private int _checkValue;

    private void OnEnable()
    {
        var total = PlayerPrefs.GetInt("TotalScore", 0);

        if (total >= _checkValue)
        {
            _moreEqualEvent?.Invoke();
        }
        else
        {
            _lessEvent?.Invoke();
        }
    }
}
