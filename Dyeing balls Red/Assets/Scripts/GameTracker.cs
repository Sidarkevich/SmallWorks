using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTracker : MonoBehaviour
{
    public UnityEvent GameStartEvent;
    public UnityEvent GameEndEvent;

    [SerializeField] private TouchUIDetector _gamePanel;
    [SerializeField] private Ball _ball;

    private void Start()
    {
        _gamePanel.PlayerTouchedEvent.AddListener(OnPlayerTouched);
        _ball.BallLostEvent.AddListener(OnBallLost);
    }

    private void OnPlayerTouched()
    {
        GameStartEvent?.Invoke();
    }

    private void OnBallLost()
    {
        GameEndEvent?.Invoke();
    }
}
