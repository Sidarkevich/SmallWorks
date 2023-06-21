using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] private int _scoreValue;
    [SerializeField] private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var handler = collider.GetComponent<ScoreHandler>();

        if (handler)
        {
            handler.IncreaseScore(_scoreValue);
            _collider.enabled = false;
        }
    }
}
