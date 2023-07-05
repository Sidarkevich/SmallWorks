using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent StartedEvent;
    public UnityEvent FinishedEvent;

    [SerializeField] private float _duration;

    public void StartTimer()
    {
        StartedEvent?.Invoke();
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(_duration);

        FinishedEvent?.Invoke();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}