using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickInput : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Checker _checker;

    public void OnPointerDown(PointerEventData eventData)
    {
        _checker.Check();
    }
}
