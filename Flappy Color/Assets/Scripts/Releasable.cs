using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Releasable : MonoBehaviour
{
    [SerializeField] private DirectionMovement _movement;

    public DirectionMovement Movement => _movement;

    private UnityEvent<Releasable> ReleasedEvent = new UnityEvent<Releasable>();

    public void Activate()
    {
        gameObject.SetActive(true);
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
