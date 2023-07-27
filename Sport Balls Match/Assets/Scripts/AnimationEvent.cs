using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _animationEvent;

    public void InvokeEvent()
    {
        _animationEvent?.Invoke();
    }
}
