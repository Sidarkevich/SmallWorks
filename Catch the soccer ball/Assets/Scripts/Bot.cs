using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bot : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnMovedEvent; 

    private Cell _currentCell;

    public void Move(int moves)
    {
        OnMovedEvent?.Invoke();
    }
}
