using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private UnityEvent ClickedEvent;
    [SerializeField] private Dart _dart;

    private Camera _camera;

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickedEvent?.Invoke();
        _dart.SetTarget(eventData.pointerCurrentRaycast.worldPosition);
    }
}
