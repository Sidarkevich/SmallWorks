using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _ballDetected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var ball = collider.GetComponent<Ball>();

        if (ball)
        {
            _ballDetected?.Invoke();
        }
    }
}
