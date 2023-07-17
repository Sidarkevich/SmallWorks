using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<Releasable> _prefabs;
    private List<Releasable> _objects;
    private List<Releasable> _inactiveObjects = new List<Releasable>();

    public void DeactivateAllType(System.Type type)
    {
        foreach (var obj in _objects)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                if (obj.Element.GetType() == type)
                {
                    OnReleased(obj);
                }
            }
        }
    }

    public Releasable ActivateObject()
    {
        if (_inactiveObjects.Count != 0)
        {
            var obj = _inactiveObjects[Random.Range(0, _inactiveObjects.Count)];
            _inactiveObjects.Remove(obj);
            obj.gameObject.SetActive(true);
            return obj;
        }

        var additional = Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], transform);
        additional.AddReleaseListener(OnReleased);
        _objects.Add(additional);
        return additional;
    }

    public void Init()
    {
        _objects = new List<Releasable>(transform.GetComponentsInChildren<Releasable>());

        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
            obj.AddReleaseListener(OnReleased);
            _inactiveObjects.Add(obj);
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
        releasable.gameObject.SetActive(false);
        _inactiveObjects.Add(releasable);
    }

    private void DeactivateAll()
    {
        _inactiveObjects.Clear();

        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
            _inactiveObjects.Add(obj);
        }
    }
}
