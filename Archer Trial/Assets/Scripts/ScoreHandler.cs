using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    [HideInInspector] public UnityEvent<int> ScoreChangedEvent;
    [SerializeField] private UnityEvent _scoreIncreasedEvent;
    [SerializeField] private LevelHandler _level;

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

    public void Increase(int value)
    {
        if (value > 0)
        {
            Score += value;
            _scoreIncreasedEvent?.Invoke();
        }
    }

    private void OnEnable()
    {
        Score = 0;
    }
}
