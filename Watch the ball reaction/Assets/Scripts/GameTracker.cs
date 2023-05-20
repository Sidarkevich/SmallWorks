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
    
    public void OnBallClicked(Ball clicked)
    {
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
