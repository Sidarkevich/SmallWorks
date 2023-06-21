using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnChance;

    [SerializeField] private float _yMin;
    [SerializeField] private float _yMax;

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
                if (Random.Range(0f, 1f) <= _spawnChance)
                {
                    var yPos = Random.Range(_yMin, _yMax);
                    Debug.Log(yPos);

                    var obj = Instantiate(_prefab, new Vector3(transform.position.x, yPos / 80, transform.position.z), Quaternion.identity, transform);
                }

                _counter = 0;
            }
        }    
    }
}
