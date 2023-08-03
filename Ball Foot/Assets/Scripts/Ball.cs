using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void OnEnable()
    {
        _rigidbody.position = _startPosition;
        _rigidbody.SetRotation(_startRotation);
    }

    private void FixedUpdate()
    {
        _rigidbody.MoveRotation(_rigidbody.rotation - _rigidbody.velocity.x * _rotationSpeed);
    }
}
