using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public UnityEvent LossEvent;
    public UnityEvent ScoreIncreasedEvent;

    [HideInInspector] public UnityEvent<int> ScoreChangedEvent;

    private int _score;

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            ScoreChangedEvent?.Invoke(_score);
        }
    }

    public void Loss()
    {
        LossEvent?.Invoke();
    }

    public void Increase(int value)
    {
        if (value > 0)
        {
            Score += value;
            ScoreIncreasedEvent?.Invoke();
        }
    }

    private void OnEnable()
    {
        Score = 0;
    }
}
