using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeActivator : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private bool _activateOnStart;
    [SerializeField] [Range(0f, 1f)] private float _chance;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private SpeedHandler _speed;
    [SerializeField] private float _speedIncrement;

    private void Awake()
    {
        _pool.Init();
    }

    private void OnEnable()
    {
        _pool.Activate();
        _speed.Reset();

        if (_activateOnStart)
        {
            Activate();
        }

        StartCoroutine(ActivationCoroutine());
    }

    private void OnDisable()
    {
        _pool.Deactivate();
        StopAllCoroutines();
    }

    private IEnumerator ActivationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);

            if (Random.Range(0f, 1f) < _chance)
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        var spawned = _pool.ActivateObject();

        spawned.transform.position = transform.position;
        spawned.Movement.Init(_speed);

        _speed.Increase(_speedIncrement);
    }
}
