using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirectionMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent _outOfViewEvent;
    [SerializeField] private Vector3 _moveDirection;
    
    private float _destroyValue;

    private void Start()
    {
        _destroyValue = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * SpeedHandler.SpeedValue * Time.deltaTime);

        if (transform.position.y < _destroyValue)
        {
            _outOfViewEvent?.Invoke();
        }
    }
}
