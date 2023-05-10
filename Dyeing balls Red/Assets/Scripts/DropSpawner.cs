using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] private GameTracker _tracker;
    [SerializeField] private Transform _leftCorner;
    [SerializeField] private Transform _rightCorner;
    [SerializeField] private float _spawnTime;
    [SerializeField] private GameObject[] _dropTypes;

    private void Start()
    {
        _tracker.GameStartEvent.AddListener(StartSpawn);
        _tracker.GameEndEvent.AddListener(StopSpawn);
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void StopSpawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            var toDrop = _dropTypes[UnityEngine.Random.Range(0, _dropTypes.Length)];
            var leftPos = _leftCorner.position;
            var rightPos = _rightCorner.position;

            var startPos = new Vector3(UnityEngine.Random.Range(leftPos.x, rightPos.x), leftPos.y, leftPos.z);

            Instantiate( toDrop, startPos, Quaternion.identity);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
