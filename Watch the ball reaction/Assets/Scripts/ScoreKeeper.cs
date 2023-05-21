using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreKeeper : MonoBehaviour
{
    public UnityEvent<int> ScoreUpdatedEvent;

    public int ScoreValue
    {
        get => _score;
        set
        {
            _score = value;
            BallMovement.Speed += 0.1f;

            var bestScore = PlayerPrefs.GetInt("BestScore", 0);
            if (_score > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", _score);
            }

            ScoreUpdatedEvent?.Invoke(_score);
        }
    }

    private int _score;

    private void OnEnable()
    {
        ScoreValue = 0;
    }
}
