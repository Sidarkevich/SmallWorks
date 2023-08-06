using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string _groundParameter = "isGrounded";

    public bool IsGrounded => _isGrounded;
    private bool _isGrounded;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        _isGrounded = true;
        _animator.SetBool(_groundParameter, _isGrounded);
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        _isGrounded = false;
        _animator.SetBool(_groundParameter, _isGrounded);
    }
}
