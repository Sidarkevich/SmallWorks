using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchUIDetector : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent PlayerTouchedEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Player clicked!");
        PlayerTouchedEvent?.Invoke();
    }
}
