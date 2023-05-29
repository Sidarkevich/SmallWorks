using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bot : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnMovedEvent;

    [SerializeField] private Cell _startCell;
    [SerializeField] private CellMap _map;

    private Cell _currentCell;

    public void Move(int moves)
    {
        // Get next cell
        OnMovedEvent?.Invoke();
    }

    private void OnEnable()
    {
        _currentCell = _startCell;
        transform.position = _currentCell.transform.position;
        _currentCell.ChangeState(Cell.CellState.Player);
    }
}
