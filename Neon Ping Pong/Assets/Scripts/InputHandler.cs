using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] private SliderSetter _setter;

    public void OnPointerDown(PointerEventData eventData)
    {
        _setter.ChangeDirection(SliderSetter.Direction.Positive);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _setter.ChangeDirection(SliderSetter.Direction.Negative);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _setter.ChangeDirection(SliderSetter.Direction.Negative);
    }
}
