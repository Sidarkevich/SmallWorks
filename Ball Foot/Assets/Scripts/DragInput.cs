using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour, IDragHandler
{
    [SerializeField] Rigidbody2D _rigidbody;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.isValid)
        {
            _rigidbody.MovePosition(eventData.pointerCurrentRaycast.worldPosition);
        }
    }
}
