using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DirectionMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    
    private UnityEvent<DirectionMovement> ReleasedEvent = new UnityEvent<DirectionMovement>();
    private float _destroyValue;

    public void AddReleaseListener(UnityAction<DirectionMovement> callback)
    {
        ReleasedEvent.AddListener(callback);
    }

    private void Start()
    {
        _destroyValue = Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1f;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * SpeedHandler.SpeedValue * Time.deltaTime);

        if (transform.position.y < _destroyValue)
        {
            ReleasedEvent?.Invoke(this);
        }
    }
}
