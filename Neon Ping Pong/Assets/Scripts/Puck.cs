using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Puck : MonoBehaviour
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private Rigidbody2D _rigidbody;

    private void Activate()
    {
        var _startDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _rigidbody.AddForce(_startDirection * 2.0f, ForceMode2D.Impulse);
    }

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _rigidbody = GetComponent<Rigidbody2D>();

        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
