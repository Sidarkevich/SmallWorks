using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _forceValue;

    private Vector3 _direction;
    private float _gravity = -9.8f;
    private float _strength = 5f;

    public void Kick()
    {
        _direction = Vector3.up * _strength;
    }

    private void Update()
    {
        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }
}
