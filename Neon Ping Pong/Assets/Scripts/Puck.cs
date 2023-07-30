using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Puck : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private Rigidbody2D _rigidbody;

    public void Activate()
    {
        gameObject.SetActive(true);
        transform.position = _startPosition;
        transform.rotation = _startRotation;

        var _startDirection = GetRandomDirection();
        _rigidbody.AddForce(_startDirection * _speed, ForceMode2D.Impulse);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private Vector2 GetRandomDirection()
    {
        var angel = Random.Range(0f, 6.28319f);
        return new Vector2(Mathf.Cos(angel), Mathf.Sin(angel));
    }

    private void FixedUpdate()
    {
        _rigidbody.MoveRotation(_rigidbody.rotation - _rigidbody.velocity.x * _rotationSpeed);
    }
}
