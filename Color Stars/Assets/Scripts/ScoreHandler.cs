using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public UnityEvent LossEvent;

    [HideInInspector] public UnityEvent<int> ScoreChangedEvent;
    [HideInInspector] public UnityEvent<int> BestScoreChangedEvent;

    private int _score;
    private int _bestScore;

    public int BestScore => _bestScore;

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            ScoreChangedEvent?.Invoke(_score);
        }
    }

    public void Reset()
    {
        Score = 0;
    }

    public void Loss()
    {
        SaveResult();
        LossEvent?.Invoke();
    }

    public void IncreaseScore(int value)
    {
        if (value > 0)
        {
            Score += value;

            if (Score > _bestScore)
            {
                _bestScore = Score;
                BestScoreChangedEvent?.Invoke(_bestScore);
            }
        }
    }

    private void SaveResult()
    {
        var lastBest = PlayerPrefs.GetInt("BestScore", 0);

        if (_bestScore > lastBest)
        {
            PlayerPrefs.SetInt("BestScore", _bestScore);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }
}