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
            _score = value;
            ScoreChangedEvent?.Invoke(_score);
        }
    }

    public void SaveResult()
    {
        var lastBest = PlayerPrefs.GetInt("BestScore", 0);

        if (_score > lastBest)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            PlayerPrefs.Save();
        }
    }
}
