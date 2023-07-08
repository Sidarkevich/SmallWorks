using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<DirectionMovement> _prefabs;
    
    private List<DirectionMovement> _objects;
    private int _freeCount;
    private float _spawnX;

    public DirectionMovement ActivateObject()
    {
        if (_freeCount > 0)
        {
            _freeCount--;

            foreach (var obj in _objects)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }
        }

        _freeCount = 0;
        var additional = Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], transform); 
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
        }

        _freeCount = _objects.Count;
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
        _freeCount++;
    }

    private void DeactivateAll()
    {
        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
