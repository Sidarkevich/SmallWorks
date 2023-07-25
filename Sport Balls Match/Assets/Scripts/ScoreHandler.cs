using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
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

    public void ResetScore()
    {
        Score = 0;
    }

    public void IncreaseScore(int value)
    {
        if (value > 0)
        {
            Score += value;
        }
    }
}
