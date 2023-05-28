using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCondition : MonoBehaviour
{
    [HideInInspector] public UnityEvent LevelCompletedEvent;
    [HideInInspector] public UnityEvent LevelFailedEvent;

    [SerializeField] private Ball[] _balls;

    private int _currentScore;
    private AudioPlayer _player;

    private void Awake()
    {
        _player = FindObjectOfType<AudioPlayer>();

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

        _player.PlayClick();

        if (_currentScore >= _balls.Length)
        {
            LevelCompletedEvent?.Invoke();
        }
    }

    private void OnBallInvisible()
    {
        LevelFailedEvent?.Invoke();
    }
}
