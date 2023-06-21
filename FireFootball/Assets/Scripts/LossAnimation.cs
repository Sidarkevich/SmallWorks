using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LossAnimation : MonoBehaviour
{
    public UnityEvent StartedEvent;
    public UnityEvent FinishedEvent;

    [SerializeField] private float _animationDuration;

    public void StartAnimation()
    {
        StartedEvent?.Invoke();
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        yield return new WaitForSeconds(_animationDuration);

        FinishedEvent?.Invoke();
    }
}
