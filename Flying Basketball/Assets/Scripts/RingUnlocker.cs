using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RingUnlocker : MonoBehaviour
{
    public UnityEvent UnlockedEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if (ball)
        {
            Debug.Log("UNLOCKED!");
            UnlockedEvent?.Invoke();
        }
    }
}
