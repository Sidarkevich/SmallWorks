using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SpotInput : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<Spot> ClickedEvent;
    public Spot Spot => _spot;

    [SerializeField] private Spot _spot;

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickedEvent?.Invoke(_spot);
    }
}
