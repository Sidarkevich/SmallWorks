using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirectionMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent _outOfViewEvent;
    [SerializeField] private Vector3 _moveDirection;

    private float _destroyValue;
    /*    private SpeedHandler _handler;

        public void Init(SpeedHandler handler)
        {
            _handler = handler;
        }*/

    private void Start()
    {
        _destroyValue = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * Time.deltaTime);

        if (transform.position.x < _destroyValue)
        {
            _outOfViewEvent?.Invoke();
        }
    }
}