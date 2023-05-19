using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    [HideInInspector] public UnityEvent<CellState> StateChangedEvent;
    public UnityEvent LockedEvent;
    public UnityEvent UnlockedEvent;

    public enum CellState
    {
        Border,
        Free,
        Filled
    }

    public CellState State => _state;
    [SerializeField] private CellState _state;

    public void ChangeState()
    {
        if (_state == CellState.Free)
        {
            _state = CellState.Filled;
            StateChangedEvent?.Invoke(_state);
        }
    }

    public void Lock(int moves)
    {
        LockedEvent?.Invoke();
    }

    public void Unlock()
    {
        UnlockedEvent?.Invoke();
    }
}
