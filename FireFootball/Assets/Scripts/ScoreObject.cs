using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreObject : MonoBehaviour
{
    public UnityEvent ScoreCollectedEvent;

    [SerializeField] private int _scoreValue;
    [SerializeField] private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var handler = collider.GetComponent<ScoreHandler>();

        if (handler)
        {
            handler.IncreaseScore(_scoreValue);
            _collider.enabled = false;

            ScoreCollectedEvent?.Invoke();
        }
    }
}
