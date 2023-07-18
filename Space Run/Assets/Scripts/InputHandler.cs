using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RocketMovement _rocket;

    public void OnDrag(PointerEventData eventData)
    {
        _rocket.SetTarget(eventData.pointerCurrentRaycast.worldPosition);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rocket.SetTarget(eventData.pointerCurrentRaycast.worldPosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _rocket.StopMove();
    }
}
