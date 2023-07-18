using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Element))]
public class Releasable : MonoBehaviour
{
    [SerializeField] private Element _element;
    [SerializeField] private DirectionMovement _movement;
    [SerializeField] private Animation _animation;

    public Element Element => _element;
    public DirectionMovement Movement => _movement;

    private UnityEvent<Releasable> ReleasedEvent = new UnityEvent<Releasable>();

    public void Activate()
    {
        gameObject.SetActive(true);
        _animation.Play("OnActivate");
    }

    public void Deactivate()
    {
        _animation.Play("OnDeactivate");
    }

    public void AddReleaseListener(UnityAction<Releasable> callback)
    {
        ReleasedEvent.AddListener(callback);
    }

    public void Release()
    {
        ReleasedEvent?.Invoke(this);
        gameObject.SetActive(false);
    }
}
