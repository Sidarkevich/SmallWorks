using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    [HideInInspector] public UnityEvent<int> ScoreChangedEvent;

    public int Score => _score;

    private int _score;

    public void IncreaseScore(int value)
    {
        if (_score + value > _score)
        {
            _score += value;
            ScoreChangedEvent?.Invoke(_score);
        }
    }

    private void OnEnable()
    {
        _score = 0;
        ScoreChangedEvent?.Invoke(_score);
    }
}
