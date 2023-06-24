using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _strength = 6f;
    [SerializeField] private Animation _animation;

    private Transform _startTransform;

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
        _animation.Play();
        _body.velocity = Vector2.up * _strength;
    }

    private void Awake()
    {
        _startTransform = transform;
    }

    private void OnEnable()
    {
        transform.position = _startTransform.position;
        transform.rotation = _startTransform.rotation;
    }
}
