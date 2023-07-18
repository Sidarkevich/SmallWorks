using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStarter : MonoBehaviour
{
    [SerializeField] private ObjectPool _sunPool;
    [SerializeField] private ObjectPool _elementPool;
    [SerializeField] private TimeActivator _timeActivator;
    [SerializeField] private SunActivator _sunActivator;

    private void Awake()
    {
        _sunPool.Init();
        _elementPool.Init();
    }

    private void OnEnable()
    {
        _timeActivator.Activate();
        _sunActivator.Activate();
    }

    private void OnDisable()
    {
        _sunPool.Deactivate();
        _elementPool.Deactivate();

        _timeActivator.Deactivate();
    }
}
