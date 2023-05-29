using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    [HideInInspector] public UnityEvent<CellState, bool> StateChangedEvent;
    public UnityEvent LockedEvent;
    public UnityEvent UnlockedEvent;

    public enum CellState
    {
        Border,
        Free,
        Filled,
        Player
    }

    public CellState State => _state;
    [SerializeField] private CellState _state;
    public Vector3 QrsPosition => _qrsPosition;
    [SerializeField] private Vector3 _qrsPosition;

    public void ChangeState(CellState state, bool byPlayer)
    {
        _state = state;
        StateChangedEvent?.Invoke(_state, byPlayer);
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
