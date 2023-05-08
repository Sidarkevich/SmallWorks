using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent BallDeathEvent;
    public UnityEvent<int> BallGetHitEvent;
    public UnityEvent<int> BallGetBuffEvent;
    public UnityEvent BallFullOfBuffEvent;

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
            BallGetHitEvent?.Invoke(damage);

            return;
        }
        
        BallDeathEvent?.Invoke();
    }

    public void GetBuff(int buff)
    {
        if (_buffCount + buff < _maxBuffCount)
        {
            _buffCount += buff;
            BallGetBuffEvent?.Invoke(buff);

            return;
        }

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