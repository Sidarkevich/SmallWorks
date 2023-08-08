using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public UnityEvent LossEvent;

    [HideInInspector] public UnityEvent<int> ScoreChangedEvent;

    [SerializeField] private int _scorePerSecond;
    [SerializeField] private SpeedHandler _speedHandler;

    private int _score;

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            ScoreChangedEvent?.Invoke(_score);
        }
    }

    public void Loss()
    {
        SaveBestResult();
        LossEvent?.Invoke();
    }

    private void IncreaseScore(int value)
    {
        if (value > 0)
        {
            Score += value;
            _speedHandler.Increase(value);
        }
    }

    private void SaveBestResult()
    {
        var lastBest = PlayerPrefs.GetInt("BestScore", 0);

        if (_score > lastBest)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            PlayerPrefs.Save();
        }
    }

    public void Reset()
    {
        Score = 0;
        _speedHandler.Reset();
        StartCoroutine(ScoreCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator ScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / _scorePerSecond);

            IncreaseScore(1);
        }
    }
}