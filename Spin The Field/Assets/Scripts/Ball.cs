using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        _rb.MoveRotation(_rb.rotation - _rb.velocity.x * _rotationSpeed);
    }
}
