using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private Animation _animation;

    private float _minPosition;
    private float _lowSpeed;
    private float _speed;

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        _minPosition = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;

        _speed = _startSpeed;
        _lowSpeed = _speed / 4;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime * SpeedScaler.SpeedCorrection);

        if (transform.position.x < _minPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if (ball)
        {
            //_animation.Play();
            Destroy(gameObject);
        }
    }
}
