using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCondition : MonoBehaviour
{
    public UnityEvent LevelCompletedEvent;
    public UnityEvent LevelFailedEvent;

    [SerializeField] private Ball[] _balls;

    private int _currentScore;

    private void Awake()
    {
        foreach (var ball in _balls)
        {
            ball.BallInvisibleEvent.AddListener(OnBallInvisible);
            ball.BallInBasketEvent.AddListener(OnBallInBasket);
        }
    }

    private void OnDestroy()
    {
        foreach (var ball in _balls)
        {
            ball.BallInvisibleEvent.RemoveListener(OnBallInvisible);
            ball.BallInBasketEvent.RemoveListener(OnBallInBasket);
        }
    }

    private void OnBallInBasket()
    {
        _currentScore++;

        if (_currentScore >= _balls.Length)
        {
            Debug.Log("Level completed!");
            LevelCompletedEvent?.Invoke();
        }
    }

    private void OnBallInvisible()
    {
        Debug.Log("Level failed!");
        LevelFailedEvent?.Invoke();
    }
}
