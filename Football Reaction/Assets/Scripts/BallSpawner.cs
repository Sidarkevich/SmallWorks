using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private Transform[] _playersTransforms;

    private float _yStartPosition;
    private float _yDestroyPosition;
    private float _yBallSize;
    private int _spawnedCount;

    private void Awake()
    {
        _yBallSize = _ballPrefab.GetComponent<Collider2D>().bounds.size.y;

        var camera = Camera.main; 
        _yStartPosition = camera.ScreenToWorldPoint(Vector3.zero).y - _yBallSize;
        _yDestroyPosition = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 0)).y + _yBallSize;
    }

    private void OnEnable()
    {
        _spawnedCount = 0;
        StartCoroutine(SpawnCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            var position = _playersTransforms[Random.Range(0, _playersTransforms.Length)].position;
            position.y = _yStartPosition;

            var ball = Instantiate(_ballPrefab, position, Quaternion.identity, transform);
            ball.Init(Mathf.Min((_spawnedCount / 10)+2, _maxMoveSpeed), _yDestroyPosition);
            _spawnedCount++;

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
