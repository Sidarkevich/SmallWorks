using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ToggleExtension : MonoBehaviour, IPointerClickHandler 
{
    public UnityEvent ClickedEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickedEvent?.Invoke();
    }
}
