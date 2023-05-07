using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _startLifeCount;
    [SerializeField] private float _maxHorizontalOffset;
    [SerializeField] private float _maxVerticalOffset;

    private int _lifeCount;
    private Vector3 _nextPosition;

    private void Start()
    {
        _lifeCount = _startLifeCount;
    }

    public void GetDamage()
    {

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
