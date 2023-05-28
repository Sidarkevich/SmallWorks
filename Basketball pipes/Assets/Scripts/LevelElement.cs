using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelElement : MonoBehaviour
{
    public enum ElementType
    {
        Basket,
        Booster
    }

    public ElementType Type => _type;
    [SerializeField] private ElementType _type;
    [SerializeField] private Transform _towardTransform;

    public Vector3 GetBoosterDirection()
    {
        if (_towardTransform)
        {
            return (_towardTransform.transform.position - transform.position).normalized;
        }

        return Vector3.zero;
    }
}
