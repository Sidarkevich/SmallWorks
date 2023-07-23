using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Ball _ball;

    private AudioPlayer _audio;

    public void OnPointerDown(PointerEventData eventData)
    {
        _ball.Kick();
        _audio.PlayClick();
    }

    private void Awake()
    {
        _audio = FindObjectOfType<AudioPlayer>();
    }
}
