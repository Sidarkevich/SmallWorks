using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTracker : MonoBehaviour
{
    public UnityEvent GameStartedEvent;
    public UnityEvent GameFinishedEvent;

    [SerializeField] private ScoreKeeper _keeper;
    [SerializeField] private Example _example;
    [SerializeField] private AudioSource _source;

    public void OnBallClicked(Ball clicked)
    {
        _source.Play();

        if (clicked.TypeIndex == _example.CurrentExample.TypeIndex)
        {
            _keeper.ScoreValue++;
        }
        else
        {
            GameFinishedEvent?.Invoke();
        }
    }

    private void OnEnable()
    {
        GameStartedEvent?.Invoke();
    }
}
