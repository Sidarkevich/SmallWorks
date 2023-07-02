using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Toggle))]
public class ToggleExtension : MonoBehaviour, IPointerClickHandler 
{
    [SerializeField] private UnityEvent<bool> _clickedEvent;
    private Toggle _toggle;

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickedEvent?.Invoke(_toggle.isOn);
    }

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }
}
