using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _strength = 6f;

    private bool _needCalculate = true;

    public void Kick()
    {
        _body.velocity = Vector2.up * _strength;
    }
}
