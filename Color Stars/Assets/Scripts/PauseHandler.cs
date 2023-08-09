using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
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
    }

    private void Unpause()
    {
        Time.timeScale = _startTimeScale;
    }
}
