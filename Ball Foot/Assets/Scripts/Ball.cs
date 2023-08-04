using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Vector2 _velocity;

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public void Restart()
    {
        _rigidbody.position = _startPosition;
        _rigidbody.SetRotation(_startRotation);
    }

    public void Kick(Vector3 forceVector)
    {
        _rigidbody.AddForce(forceVector, ForceMode2D.Impulse);
    }

    public void SaveVelocity()
    {
        _velocity = _rigidbody.velocity;
    }

    public void SetVelocity()
    {
        _rigidbody.velocity = _velocity;
    }

    private void FixedUpdate()
    {
        _rigidbody.MoveRotation(_rigidbody.rotation - _rigidbody.velocity.x * _rotationSpeed);
    }
}
