using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent<int, int> _missCountChanged;
    [SerializeField] private int _attemptCount;
    [SerializeField] private LevelHandler _level;
    
    private int _missCount;

    private void OnEnable()
    {
        _missCount = _attemptCount;
        _missCountChanged?.Invoke(_missCount, _attemptCount);
    }

    public void Miss()
    {
        _missCount--;
        _missCountChanged?.Invoke(_missCount, _attemptCount);

        if (_missCount <= 0)
        {
            _level.Loss();
        }
    }
}
