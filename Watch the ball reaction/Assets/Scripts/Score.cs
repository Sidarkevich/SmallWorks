using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public UnityEvent<int> ScoreUpdatedEvent;

    public int ScoreValue
    {
        get => _score;
        set
        {
            _score = value;
            ScoreUpdatedEvent?.Invoke(_score);
        }
    }

    private int _score;
}
