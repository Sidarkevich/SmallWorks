using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] private Transform _leftCorner;
    [SerializeField] private Transform _rightCorner;
    [SerializeField] private float _spawnTime;
    [SerializeField] private GameObject[] _dropTypes;

    private bool _isSpawning;

    public void StartSpawn()
    {
        if (_isSpawning)
        {
            return;
        }

        _isSpawning = true;
        StartCoroutine(SpawnCoroutine());
    }

    private void StopSpawn()
    {
        _isSpawning = false;
        StopAllCoroutines();
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(_dropTypes[UnityEngine.Random.Range(0, _dropTypes.Length)],
                                    new Vector3(UnityEngine.Random.Range(_leftCorner.position.x, _rightCorner.position.x),
                                    _leftCorner.transform.position.y, _leftCorner.transform.position.z),
                                    Quaternion.identity);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
