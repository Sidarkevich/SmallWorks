using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LossAnimation : MonoBehaviour
{
    public UnityEvent AnimationStartedEvent;
    public UnityEvent AnimationFinishedEvent;

    [SerializeField] private float _animationDuration;

    public void StartAnimation()
    {
        AnimationStartedEvent?.Invoke();
        StartCoroutine(AnimationCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator AnimationCoroutine()
    {
        yield return new WaitForSeconds(_animationDuration);

        AnimationFinishedEvent?.Invoke();
    }
}
