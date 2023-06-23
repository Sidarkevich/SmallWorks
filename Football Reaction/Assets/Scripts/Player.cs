using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [HideInInspector] public UnityEvent<Player> PlayerClickedEvent;
    [HideInInspector] public UnityEvent PlayerKickedBallEvent;

    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Collider2D _collider;

    public void ChangeState(bool state)
    {
        _collider.enabled = state;
        _sprite.enabled = state;
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
            ball.Stop();
            PlayerKickedBallEvent?.Invoke();
        }
    }
}
