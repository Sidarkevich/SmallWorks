using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _strength = 6f;
    [SerializeField] private Animation _animation;

    private bool _needCalculate = true;

    public void Kick()
    {
        _animation.Play();
        _body.velocity = Vector2.up * _strength;
    }
}
