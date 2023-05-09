using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{
    [HideInInspector] public UnityEvent<int> ScoreUpdateEvent;
    public int Score => _score;

    [SerializeField] private Ball _ball;
    private int _score;

    private void Start()
    {
        _ball.BallFullOfBuffEvent.AddListener(OnFullOfBuffEvent);
    }

    private void OnFullOfBuffEvent()
    {
        _score++;
        ScoreUpdateEvent?.Invoke(_score);
    }
}
