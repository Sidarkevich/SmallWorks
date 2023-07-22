using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<Releasable> _prefabs;
    private List<Releasable> _objects;
    private List<Releasable> _inactiveObjects = new List<Releasable>();

    public Releasable ActivateObject()
    {
        if (_inactiveObjects.Count != 0)
        {
            var releasable = _inactiveObjects[Random.Range(0, _inactiveObjects.Count)];
            _inactiveObjects.Remove(releasable);
            releasable.Activate();
            return releasable;
        }

        var additional = Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], transform);
        additional.AddReleaseListener(OnReleased);
        additional.Activate();
        _objects.Add(additional);
        return additional;
    }

    public void Init()
    {
        _objects = new List<Releasable>(transform.GetComponentsInChildren<Releasable>(includeInactive: true));

        foreach (var releasable in _objects)
        {
            releasable.Release();
            releasable.AddReleaseListener(OnReleased);
            _inactiveObjects.Add(releasable);
        }
    }

    public void Activate()
    {
        DeactivateAll();
    }

    public void Deactivate()
    {
        DeactivateAll();
    }

    private void OnReleased(Releasable releasable)
    {
        _inactiveObjects.Add(releasable);
    }

    private void DeactivateAll()
    {
        _inactiveObjects.Clear();

        foreach (var releasable in _objects)
        {
            releasable.Release();
        }
    }
}