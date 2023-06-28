using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private ScoreHandler _score;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private bool _isMoving;
    private int _maxHitValue;

    public void SetTarget(Vector3 target)
    {
        if (_isMoving)
        {
            return;
        }

        _isMoving = true;
        _targetPosition = target;
    }

    public void Hit(int value)
    {
        _maxHitValue = Mathf.Max(_maxHitValue, value); 
    }

    private void CheckHit()
    {
        if (_maxHitValue > 0)
        {
            _score.IncreaseScore(_maxHitValue);
            _maxHitValue = 0;
            transform.position = _startPosition;
        }

        _score.Loss();
        _maxHitValue = 0;
    }

    private void Update()
    {
        if (_isMoving)
        {
            if (Vector3.Distance(transform.position, _targetPosition) < _stopDistance)
            {
                CheckHit();
                _isMoving = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
    }

    private void Awake()
    {
        _startPosition = transform.position;
    }
}
