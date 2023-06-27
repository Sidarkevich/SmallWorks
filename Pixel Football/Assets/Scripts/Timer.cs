using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent StartedEvent;
    public UnityEvent FinishedEvent;

    [SerializeField] private float _duration;

    public void StartAnimation()
    {
        StartedEvent?.Invoke();
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        yield return new WaitForSeconds(_duration);

        FinishedEvent?.Invoke();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
