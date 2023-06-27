using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _maxVelocity;
    [SerializeField] private Rigidbody2D _rb;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    public void SetPosition(Transform newTransform)
    {
        transform.position = newTransform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var score = collider.GetComponent<ScoreHandler>();

        if (score)
        {
            score.Increase(1);
        }
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }
}
