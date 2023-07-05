using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Spot))]
public class SpotInput : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<Spot> ClickedEvent;
    public Spot Spot => _spot;

    private Spot _spot;

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickedEvent?.Invoke(_spot);
    }

    private void Awake()
    {
        _spot = GetComponent<Spot>();
    }
}
