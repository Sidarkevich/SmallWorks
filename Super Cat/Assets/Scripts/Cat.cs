using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GroundCkeck _groundCheck;

    [SerializeField] private float _jumpForce;

    public void Jump()
    {
        if (_groundCheck.IsGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
