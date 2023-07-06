using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent ClickedEvent;

    [SerializeField] private Cat _cat;

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickedEvent?.Invoke();
        _cat.Jump();
    }
}