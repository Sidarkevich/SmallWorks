using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallContact : MonoBehaviour
{
    [SerializeField] private UnityEvent _ballContactEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var puck = collision.gameObject.GetComponent<Ball>();

        if (puck)
        {
            _ballContactEvent?.Invoke();
        }
    }
}
