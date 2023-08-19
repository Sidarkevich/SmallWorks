using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Rigidbody2D _rigidBody;

    private Vector3 _startPosition;
    private bool _isDragging;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDragging)
            return;

        if (eventData.pointerCurrentRaycast.isValid)
        {
            _rigidBody.MovePosition(eventData.pointerCurrentRaycast.worldPosition);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragging = false;
    }

    public void Setup()
    {
        _isDragging = false;
        transform.position = _startPosition;
    }

    private void Start()
    {
        _startPosition = transform.position;
    }
}