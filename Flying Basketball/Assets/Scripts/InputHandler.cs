using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Ball _ball;

    public void OnPointerDown(PointerEventData eventData)
    {
        _ball.Kick();
    }
}
