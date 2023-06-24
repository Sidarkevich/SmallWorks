using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BorderObject : MonoBehaviour
{
    public UnityEvent CollisionEvent;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        var handler = collider.gameObject.GetComponent<ScoreHandler>();

        if (handler)
        {
            CollisionEvent?.Invoke();
            handler.Loss();
        }
    }
}
