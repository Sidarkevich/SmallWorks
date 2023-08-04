using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallContact : MonoBehaviour
{
    [SerializeField] private UnityEvent _ballContactEvent;
    [SerializeField] private float _forceEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if (ball)
        {
            var rnd = new Vector3(GetRandomValue(), GetRandomValue(), 0);

            _ballContactEvent?.Invoke();
            ball.Kick((ball.transform.position - transform.position + rnd) * _forceEffect);
        }
    }

    private float GetRandomValue()
    {
        return UnityEngine.Random.Range(-1f, 1f);
    }
}
