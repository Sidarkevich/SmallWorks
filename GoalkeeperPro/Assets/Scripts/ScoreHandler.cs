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
        set
        {
            SaveKeep(value - _score);
            _score = value;
            ScoreChangedEvent?.Invoke(_score);
        }
    }

    public void SaveBestResult()
    {
        var lastBest = PlayerPrefs.GetInt("BestScore", 0);

        if (_score > lastBest)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            PlayerPrefs.Save();
        }
    }

    private void SaveKeep(int delta)
    {
        var score = PlayerPrefs.GetInt("TotalScore", 0);
        PlayerPrefs.SetInt("TotalScore", score+delta);
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        _score = 0;
    }
}
