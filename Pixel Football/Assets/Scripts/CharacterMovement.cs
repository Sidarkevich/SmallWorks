using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private Rigidbody2D _rb;

    private Vector3 _target;
    private bool _needMove;
    private Vector3 _startPosition;

    public void SetTarget(Vector3 target)
    {
        _target = target;
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
            var direction = _target - transform.position;

            Vector3 step = direction.normalized * _moveSpeed * Time.fixedDeltaTime;
            if (direction.magnitude < step.magnitude)
            {
                step = direction;
            }
            _rb.MovePosition(transform.position + step);
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
