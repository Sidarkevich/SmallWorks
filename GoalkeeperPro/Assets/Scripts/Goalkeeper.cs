using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _moveEndPoint; 
    [SerializeField] private ScoreHandler _handler;

    private Vector3 _moveDirection = Vector3.zero;

    public void Hit()
    {
        _handler.Score++;
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
}
