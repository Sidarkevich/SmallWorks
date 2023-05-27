using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Basket : MonoBehaviour
{
    public UnityEvent BallInBasketEvent;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var ball = collider.GetComponent<Ball>();

        if (ball)
        {
            BallInBasketEvent?.Invoke();
            Destroy(ball.gameObject);
        }
    }
}
