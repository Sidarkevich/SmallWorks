using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [HideInInspector] public UnityEvent BallInvisibleEvent;
    [HideInInspector] public UnityEvent BallInBasketEvent;

    private bool _isInBasket;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

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
        var element = collider.GetComponent<LevelElement>();

        if (!element)
        {
            return;
        }

        if (element.Type == LevelElement.ElementType.Basket)
        {
            _isInBasket = true;

            BallInBasketEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        var element = collider.GetComponent<LevelElement>();

        if (!element)
        {
            return;
        }

        if (element.Type == LevelElement.ElementType.Booster)
        {
            _rigidbody.AddForce(element.GetBoosterDirection() * 100, ForceMode2D.Force);
        }
    }
}
