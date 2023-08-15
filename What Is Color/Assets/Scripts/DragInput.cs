using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private Rigidbody2D _rigidBody;

    private Vector3 _startPosition;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.isValid)
        {
            _rigidBody.MovePosition(eventData.pointerCurrentRaycast.worldPosition);
        }
    }

    private void OnEnable()
    {
        _rigidBody.MovePosition(_startPosition);
    }

    private void Start()
    {
        _startPosition = transform.position;
    }
}