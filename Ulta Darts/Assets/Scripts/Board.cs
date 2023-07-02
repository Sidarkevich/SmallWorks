using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private AnimationClip _disappearanceClip;
    [SerializeField] private AnimationClip _appearanceClip;

    private UnityEvent _disappearedEvent = new UnityEvent();

    public void Disappear()
    {
        _animation.clip = _disappearanceClip;
        _animation.Play();
    }

    public void AddDisappearedListener(UnityAction action)
    {
        _disappearedEvent.AddListener(action);
    }

    public void InvokeDisappearedEvent()
    {
        _disappearedEvent?.Invoke();
    }

    private void OnEnable()
    {
        _animation.clip = _appearanceClip;
        _animation.Play();
    }

    private void OnDisable()
    {
        _disappearedEvent.RemoveAllListeners();
    }
}
