using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Player> PlayerClickedEvent;

    [SerializeField] private SpriteRenderer _sprite;

    private bool _isActive = true;

    public void ChangeState(bool state)
    {
        _isActive = state;
        _sprite.enabled = _isActive;
    }

    private void OnMouseUpAsButton()
    {
        PlayerClickedEvent?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var ball = collider.GetComponent<Ball>();

        if (ball)
        {
            if (_isActive)
            {
                Debug.Log("LOSS!");

                ball.Destroy();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var ball = collider.GetComponent<Ball>();

        if (ball)
        {
            if (!_isActive)
            {
                Debug.Log("SCORE++");
            }
        }
    }
}
