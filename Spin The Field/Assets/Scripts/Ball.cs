using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _rotationSpeed;

    private AudioPlayer _audio;

    private void Start()
    {
        _audio = FindObjectOfType<AudioPlayer>();
    }

    private void FixedUpdate()
    {
        _rb.MoveRotation(_rb.rotation - _rb.velocity.x * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audio.PlayKick();
    }
}
