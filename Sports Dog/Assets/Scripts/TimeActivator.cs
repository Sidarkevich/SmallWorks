using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeActivator : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] [Range(0f, 1f)] private float _chance;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private SpeedHandler _speedHandler;

    private void OnEnable()
    {
        StartCoroutine(ActivationCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator ActivationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);

            if (Random.Range(0f, 1f) < _chance)
            {
                var spawned = _pool.ActivateObject();
                spawned.Init(_speedHandler);

                spawned.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}