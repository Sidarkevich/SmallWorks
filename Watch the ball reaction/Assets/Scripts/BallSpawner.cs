using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Ball[] Balls => _balls;

    [SerializeField] private GameTracker _tracker;
    [SerializeField] private float _spawnTime;
    [SerializeField] private Ball[] _balls;
    [SerializeField] private Transform _topPoint;
    [SerializeField] private Transform _bottomPoint;

    public void StartSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Vector3 rndPosition = new Vector3(_topPoint.transform.position.x, Random.Range(_bottomPoint.transform.position.y, _topPoint.transform.position.y), 0);
            var ball = Instantiate(_balls[Random.Range(0, _balls.Length)], rndPosition, Quaternion.identity);
            ball.BallClickedEvent.AddListener(_tracker.OnBallClicked);

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
