using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuckContact : MonoBehaviour
{
    [SerializeField] private UnityEvent _puckContactEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var puck = collision.gameObject.GetComponent<Puck>();

        if (puck)
        {
            _puckContactEvent?.Invoke();
        }
    }
}
