using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeActivator : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] [Range(0f, 1f)] private float _chance;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private ScoreHandler _score;
    [SerializeField] private float _speedIncrease;

    private void OnEnable()
    {
        StartCoroutine(ActivationCoroutine());
        SpeedHandler.ResetSpeed();
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
                
                var xPos = Random.Range(_leftBorder.position.x, _rightBorder.position.x);
                spawned.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
                spawned.Element.Init(_score, _pool);
                SpeedHandler.ChangeSpeed(SpeedHandler.SpeedValue + _speedIncrease);
            }
        }
    }
}