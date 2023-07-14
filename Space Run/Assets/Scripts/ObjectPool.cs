using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<DirectionMovement> _prefabs;
    private List<DirectionMovement> _objects;
    private List<DirectionMovement> _inactiveObjects = new List<DirectionMovement>();

    public void DeactivateAllType(System.Type type)
    {
        foreach (var obj in _objects)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                var element = obj.GetComponent<Element>();

                if (element.GetType() == type)
                {
                    OnReleased(obj);
                }
            }
        }
    }

    public DirectionMovement ActivateObject()
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

    private void Awake()
    {
        _objects = new List<DirectionMovement>(transform.GetComponentsInChildren<DirectionMovement>());

        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
            obj.AddReleaseListener(OnReleased);
            _inactiveObjects.Add(obj);
        }
    }

    private void OnEnable()
    {
        DeactivateAll();
    }

    private void OnDisable()
    {
        DeactivateAll();
    }

    private void OnReleased(DirectionMovement movement)
    {
        movement.gameObject.SetActive(false);
        _inactiveObjects.Add(movement);
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
