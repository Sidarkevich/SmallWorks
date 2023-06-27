using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public UnityEvent WinEvent;
    public UnityEvent ScoreIncreasedEvent;

    [SerializeField] private int _scoreToWin;

    [HideInInspector] public UnityEvent<int> ScoreChangedEvent;

    private int _score;

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            ScoreChangedEvent?.Invoke(_score);

            if (_score >= _scoreToWin)
            {
                WinEvent?.Invoke();
            }
        }
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
