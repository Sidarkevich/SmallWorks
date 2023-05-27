using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [HideInInspector] public UnityEvent BallInvisibleEvent;
    [HideInInspector] public UnityEvent BallInBasketEvent;

    private bool _isInBasket;

    private void OnBecameInvisible()
    {
        if (!_isInBasket)
        {
            BallInvisibleEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var basket = collider.GetComponent<Basket>();

        if (basket)
        {
            _isInBasket = true;

            BallInBasketEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
