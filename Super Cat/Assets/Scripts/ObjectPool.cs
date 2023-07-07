using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<DirectionMovement> _prefabs;
    
    private List<DirectionMovement> _objects;
    private int _activeCount;

    private void Awake()
    {
        _objects = new List<DirectionMovement>(transform.GetComponentsInChildren<DirectionMovement>());

        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
            obj.AddReleaseListener(OnReleased);
        }
    }

    private void OnEnable()
    {
        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        foreach (var obj in _objects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private void ActivateObject()
    {

    }

    private void DeactivateObject()
    {
        
    }

    private void OnReleased(DirectionMovement movement)
    {

    }
}
