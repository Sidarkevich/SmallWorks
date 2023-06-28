using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Dart _dart;

    private Camera _camera;

    public void OnPointerDown(PointerEventData eventData)
    {
        _dart.SetTarget(eventData.pointerCurrentRaycast.worldPosition);
    }
}
