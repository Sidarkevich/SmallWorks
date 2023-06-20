using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnTime;

    private float _yMax;
    private float _yMin;

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

    private void Start()
    {
        _yMin = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight*0.25f, 0)).y;
        _yMax = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight*(1f - 0.35f), 0)).y;
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
                var yPosition = Random.Range(_yMin, _yMax);
                Instantiate(_prefab, new Vector3(transform.position.x, yPosition, transform.position.z), Quaternion.identity, transform);

                _counter = 0;
            }
        }    
    }
}
