using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchUIDetector : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent PlayerTouchedEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Player clicked!");
        PlayerTouchedEvent?.Invoke();
    }
}
