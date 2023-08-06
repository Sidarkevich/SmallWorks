using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private float _jumpForce;

    private Vector3 _startPosition;

    public void Jump()
    {
        if (_groundCheck.IsGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Hit()
    {
    
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
