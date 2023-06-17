using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Transform _maxSpawnPoint;
    [SerializeField] private float _spawnTime;
    [SerializeField] private Transform _parentTransform;

    private float _counter;
    private bool _isActive = false;

    private void OnEnable()
    {
        StartSpawn();
    }

    private void OnDisable()
    {
        StopSpawn();
    }

    private void StartSpawn()
    {
        _isActive = true;
        _counter = 0;
    }

    private void StopSpawn()
    {
        _isActive = false;
    }

    private void Update()
    {
        if (_isActive)
        {
            _counter += Time.deltaTime;

            if (_counter > _spawnTime)
            {
                var xPosition = Random.Range(-_maxSpawnPoint.position.x, _maxSpawnPoint.position.x);
                Instantiate(_ballPrefab, new Vector3(xPosition, transform.position.y, transform.position.z), Quaternion.identity, _parentTransform);

                _counter = 0;
            }
        }    
    }
}
