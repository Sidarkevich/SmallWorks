using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public UnityEvent LossEvent;

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

    public void Reset()
    {
        Score = 0;
    }

    public void Loss()
    {
        //SaveBestResult();
        LossEvent?.Invoke();
    }

    public void IncreaseScore(int value)
    {
        if (value > 0)
        {
            Score += value;
        }
    }

    private void SaveBestResult()
    {
        var lastBest = PlayerPrefs.GetInt("BestScore", 0);

        if (_score > lastBest)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            PlayerPrefs.Save();
        }
    }

    private void OnEnable()
    {
        Reset();
    }
}
