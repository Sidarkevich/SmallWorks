using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _lossEvent;

    [SerializeField] private SpeedHandler _speedHandler;

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
        _lossEvent?.Invoke();
    }

    public void IncreaseScore(int value)
    {
        if (value > 0)
        {
            Score += value;
            _speedHandler.IncreaseSpeed();

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