using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseHandler : MonoBehaviour
{
    public UnityEvent PausedEvent;
    public UnityEvent UnpausedEvent;

    private float _startTimeScale;

    private void OnEnable()
    {
        Pause();
    }

    private void OnDisable()
    {
        Unpause();
    }

    private void Start()
    {
        _startTimeScale = Time.timeScale;
    }

    private void Pause()
    {
        Time.timeScale = 0;
        PausedEvent?.Invoke();
    }

    private void Unpause()
    {
        Time.timeScale = _startTimeScale;
        UnpausedEvent?.Invoke();
    }
}
