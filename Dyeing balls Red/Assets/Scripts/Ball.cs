using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Ball : MonoBehaviour
{
    [HideInInspector] public UnityEvent BallDeathEvent;
    [HideInInspector] public UnityEvent BallFullOfBuffEvent;

    /// <summary>
    /// BallGetHitEvent(int currentValue, int delta)
    /// </summary>
    [HideInInspector] public UnityEvent<int, int> BallGetHitEvent;

    /// <summary>
    /// BallGetBuffEvent(int currentValue, int delta)
    /// </summary>
    [HideInInspector] public UnityEvent<int, int> BallGetBuffEvent;

    [SerializeField] private int _startLifeCount;
    [SerializeField] private int _maxBuffCount;
    [SerializeField] private float _maxHorizontalOffset;
    [SerializeField] private float _maxVerticalOffset;

    private int _lifeCount;
    private int _buffCount;
    private Vector3 _nextPosition;

    private void Start()
    {
        _lifeCount = _startLifeCount;
    }

    public void GetHit(int damage)
    {
        if (_lifeCount - damage > 0)
        {
            _lifeCount -= damage;
            BallGetHitEvent?.Invoke(_lifeCount, damage);

            return;
        }
        
        BallDeathEvent?.Invoke();
    }

    public void GetBuff(int buff)
    {
        if (_buffCount + buff < _maxBuffCount)
        {
            _buffCount += buff;
            BallGetBuffEvent?.Invoke(_buffCount, buff);

            return;
        }

        _buffCount = 0;
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
}