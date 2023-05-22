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
            if (value > _score)
            {
                BallMovement.Speed += 0.1f;

                var bestScore = PlayerPrefs.GetInt("BestScore", 0);
                if (value > bestScore)
                {
                    PlayerPrefs.SetInt("BestScore", value);
                }
            }

            _score = value;
            ScoreUpdatedEvent?.Invoke(_score);
        }
    }

    private int _score;

    private void OnEnable()
    {
        ScoreValue = 0;
        BallMovement.Speed = 2.0f;
    }
}
