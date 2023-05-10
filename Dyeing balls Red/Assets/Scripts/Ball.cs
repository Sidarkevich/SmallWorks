using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Ball : MonoBehaviour
{
    [HideInInspector] public UnityEvent BallLostEvent;
    [HideInInspector] public UnityEvent BallFullOfBuffEvent;

    /// <summary>
    /// BallGetHitEvent(int currentValue, int delta)
    /// </summary>
    [HideInInspector] public UnityEvent<int, int> BallGotHitEvent;

    /// <summary>
    /// BallGetBuffEvent(int currentValue, int delta)
    /// </summary>
    [HideInInspector] public UnityEvent<int, int> BallGotBuffEvent;

    [SerializeField] private int _startHP;
    [SerializeField] private int _maxBuffCount;
    [SerializeField] private float _maxHorizontalOffset;
    [SerializeField] private float _maxVerticalOffset;
    [SerializeField] private GameTracker _tracker;

    private int _healthPoints;
    private int _buffCount;
    private Vector3 _nextPosition;

    private void Start()
    {
        _tracker.GameStartEvent.AddListener(OnGameStarted);
    }

    public void GetHit(int damage)
    {
        if (_healthPoints - damage > 0)
        {
            _healthPoints -= damage;
            BallGotHitEvent?.Invoke(_healthPoints, damage);

            return;
        }
        
        _healthPoints = 0;
        BallGotHitEvent?.Invoke(_healthPoints, damage);
        BallLostEvent?.Invoke();
    }

    public void GetBuff(int buff)
    {
        if (_buffCount + buff < _maxBuffCount)
        {
            _buffCount += buff;
            BallGotBuffEvent?.Invoke(_buffCount, buff);

            return;
        }

        _buffCount = 0;
        BallGotBuffEvent?.Invoke(_buffCount, buff);
        BallFullOfBuffEvent?.Invoke();
    }

    public void MoveTo(Vector3 position)
    {
        _nextPosition = Vector3.zero;

        if (position.x > 0)
            _nextPosition.x = (position.x > _maxHorizontalOffset ? _maxHorizontalOffset : position.x);
        else
            _nextPosition.x = (position.x < -_maxHorizontalOffset ? -_maxHorizontalOffset : position.x);

        if (position.y > 0)
            _nextPosition.y = (position.y > _maxVerticalOffset ? _maxVerticalOffset : position.y);
        else
            _nextPosition.y = (position.y < -_maxVerticalOffset ? -_maxVerticalOffset : position.y);

        transform.position = _nextPosition;
    }

    private void OnGameStarted()
    {
        _healthPoints = _startHP;
        BallGotHitEvent?.Invoke(_healthPoints, 3);

        _buffCount = 0;
        BallGotBuffEvent?.Invoke(_buffCount, 0);
    }
}