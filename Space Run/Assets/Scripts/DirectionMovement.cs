using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirectionMovement : MonoBehaviour
{
    private UnityEvent<DirectionMovement> ReleasedEvent = new UnityEvent<DirectionMovement>();

    [SerializeField] private Vector3 _moveDirection;
    
    private float _speed;
    private float _destroyValue;

    public void AddReleaseListener(UnityAction<DirectionMovement> callback)
    {
        ReleasedEvent.AddListener(callback);
    }

    private void Start()
    {
        _destroyValue = Camera.main.ScreenToWorldPoint(Vector3.zero).y - 10f;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);

        if (transform.position.y < _destroyValue)
        {
            ReleasedEvent?.Invoke(this);
        }
    }
}
