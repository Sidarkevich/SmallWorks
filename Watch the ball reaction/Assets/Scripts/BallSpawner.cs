using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnTime;
    [SerializeField] private Ball[] _balls;
    [SerializeField] private Example _example;
    [SerializeField] private Score _score;
    [SerializeField] private Transform _topPoint;
    [SerializeField] private Transform _bottomPoint;
    [SerializeField] private Transform _borderPoint;
    [SerializeField] private Transform _ballsParent;

    private void OnEnable()
    {
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
            Vector3 rndPosition = new Vector3(_topPoint.transform.position.x, Random.Range(_bottomPoint.transform.position.y, _topPoint.transform.position.y), 0);
            var ball = Instantiate(_balls[Random.Range(0, _balls.Length)], rndPosition, Quaternion.identity);
            ball.Init(_example, _score, _borderPoint.position.x);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
