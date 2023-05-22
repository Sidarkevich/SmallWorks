using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent<Ball> BallClickedEvent;

    public int TypeIndex => _typeIndex;
    [SerializeField] private int _typeIndex;

    private void OnMouseDown()
    {
        BallClickedEvent?.Invoke(this);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        BallClickedEvent.RemoveAllListeners();
        Destroy(gameObject);
    }
}
