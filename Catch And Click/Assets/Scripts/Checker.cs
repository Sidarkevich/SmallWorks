using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    [SerializeField] private UnityEvent _rightAnswerEvent;
    [SerializeField] private UnityEvent _wrongAnswerEvent;

    [SerializeField] private BallDetector _detector;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private SpeedHandler _speedHandler;

    public void Check()
    {
        if (_detector.IsBallInside)
        {
            _speedHandler.Increase();
            _scoreHandler.Increase(1);
            _rightAnswerEvent?.Invoke();
        }
        else
        {
            _speedHandler.Reset();
            _wrongAnswerEvent?.Invoke();
        }

        _detector.Setup();
    }
}
