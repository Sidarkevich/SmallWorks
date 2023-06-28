using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    [SerializeField] private int _hitValue;

    void OnTriggerEnter2D(Collider2D collider)
    {
        var dart = collider.GetComponent<Dart>();

        if (dart)
        {
            dart.Hit(_hitValue);
        }
    }
}
