using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goalkeeper : MonoBehaviour
{
    public UnityEvent KeepedEvent;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _moveEndPoint; 
    [SerializeField] private ScoreHandler _handler;

    private Vector3 _startPosition;

    private Vector3 _moveDirection = Vector3.zero;

    public void Keep()
    {
        _handler.Score++;
        KeepedEvent?.Invoke();
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = direction;
    }

    public void Stop()
    {
        _moveDirection = Vector3.zero;
    }

    private void Update()
    {
        var delta = _moveDirection * _moveSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x + delta.x) < _moveEndPoint.position.x)
        {
            transform.Translate(delta);
        }
    }

    private void OnDisable()
    {
        transform.position = _startPosition;
    }

    private void Awake()
    {
        _startPosition = transform.position;
    }
}
