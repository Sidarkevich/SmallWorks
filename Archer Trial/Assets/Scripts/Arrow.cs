using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _maxForce;
    
    private Vector2 _startPosition;
    private Quaternion _startRotation;
    private bool _isFlying;

    public void Shoot(Vector2 mousePos)
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        var direction = new Vector2(transform.position.x, transform.position.y) - mousePos;

        _isFlying = true;
        _rb.simulated = true;
        _rb.AddForce(direction * 4.1f, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (!_isFlying)
        {
            return;
        }

        Vector2 moveDirection = _rb.velocity;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnBecameInvisible()
    {
        _isFlying = false;
        _rb.simulated = false;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rb.velocity = Vector2.zero;
    }
}
