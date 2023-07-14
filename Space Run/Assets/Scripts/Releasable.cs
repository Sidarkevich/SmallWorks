using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Element))]
public class Releasable : MonoBehaviour
{
    [SerializeField] private Element _element;
    [SerializeField] private DirectionMovement _movement;
    public Element Element => _element;
    public DirectionMovement Movement => _movement;

    private UnityEvent<Releasable> ReleasedEvent = new UnityEvent<Releasable>();

    public void Release()
    {
        ReleasedEvent?.Invoke(this);
    }

    public void AddReleaseListener(UnityAction<Releasable> callback)
    {
        ReleasedEvent.AddListener(callback);
    }
}
