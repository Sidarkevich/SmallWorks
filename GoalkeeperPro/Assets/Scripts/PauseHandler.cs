using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    private float _startTimeScale;
    private bool _isPauseActive;

    public void ChangeValue()
    {
        _isPauseActive = !_isPauseActive;

        if (_isPauseActive)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    private void Start()
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
