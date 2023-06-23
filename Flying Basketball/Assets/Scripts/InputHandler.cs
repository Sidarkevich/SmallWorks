using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Ball _ball;
    [SerializeField] private SpeedScaler _scaler;

    public void OnPointerDown(PointerEventData eventData)
    {
        _scaler.StopScaling();
        _ball.Kick();
    }
}
