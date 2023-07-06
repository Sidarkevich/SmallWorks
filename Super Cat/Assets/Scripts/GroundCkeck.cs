using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCkeck : MonoBehaviour
{
    public bool IsGrounded => _isGrounded;
    private bool _isGrounded;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        _isGrounded = false;
    }
}
