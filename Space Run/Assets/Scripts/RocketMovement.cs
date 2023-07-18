using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _leftBorder;

    private Vector3 _startPosition;
    private Vector3 _target;
    private bool _needMove;
    private Vector3 _moveDirection;

    public void StopMove()
    {
        _needMove = false;
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;

        _target.x = (_target.x > 0 ? Mathf.Min(_target.x, _rightBorder.position.x) : Mathf.Max(_target.x, _leftBorder.position.x));
        _target.z = transform.position.z;
        _needMove = true;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _target) < _stopDistance)
        {
            _needMove = false;
        }

        if (_needMove)
        {
            _moveDirection.x = _target.x - transform.position.x;

            Vector3 step = _moveDirection * _moveSpeed * Time.fixedDeltaTime;
            if (_moveDirection.magnitude < step.magnitude)
            {
                step = _moveDirection;
            }
            _rb.MovePosition(transform.position + step);
        }
    }

    private void Awake()
    {
        _startPosition = transform.position; 
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
    }
}
