using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour, IDragHandler
{
    [SerializeField] Rigidbody2D _rigidbody;

    private Vector3 _startPosition;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.isValid)
        {
            _rigidbody.MovePosition(eventData.pointerCurrentRaycast.worldPosition);
        }
    }

    public void Restart()
    {
        transform.position = _startPosition;
    }

    private void Awake()
    {
        _startPosition = transform.position;
    }
}
