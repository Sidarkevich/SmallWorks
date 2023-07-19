using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent BallCollisionEvent;
    public UnityEvent BallKickedEvent;

    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _strength;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    public void ChangeState(bool isAlive)
    {
        _body.constraints = (isAlive ? RigidbodyConstraints2D.FreezePositionX : RigidbodyConstraints2D.None);

        if (!isAlive)
        {
            _body.AddForce(Vector2.right * 20);
        }
    }

    public void Kick()
    {
        BallKickedEvent?.Invoke();
        _body.velocity = Vector2.up * _strength;
    }

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}