using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _strength = 6f;

    private Vector3 _startPosition;

    public void Kick()
    {
        _body.velocity = Vector2.up * _strength;
    }

    private void Awake()
    {
        _startPosition = transform.position;
        _startPosition.y /= 80;
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
    }
}
