using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _pausedEvent;
    [SerializeField] private UnityEvent _unpausedEvent;
    [SerializeField] private UnityEvent _clickedEvent;

    private float _startTimeScale;

    private void OnEnable()
    {
        Pause();
    }

    private void OnDisable()
    {
        Unpause();
    }

    private void Awake()
    {
        _startTimeScale = Time.timeScale;
    }

    private void Pause()
    {
        Time.timeScale = 0;
        _pausedEvent?.Invoke();
    }

    private void Unpause()
    {
        Time.timeScale = _startTimeScale;
        _unpausedEvent?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickedEvent?.Invoke();
    }
}