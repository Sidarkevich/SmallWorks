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

        var paths = _map.GetFreeDirections(_currentCell.QrsPosition);

        if (paths.Count > 0)
        {
            paths.Sort((a, b) => a.Count.CompareTo(b.Count));
            // shuffle
            var direction = paths[0];
            MakeMove(direction[0]);

            if (direction[0].State == Cell.CellState.Border)
            {
                Debug.Log("PLAYER LOST!");
            }
        }
        else
        {
            var neighbors = _map.GetFreeNeighbors(_currentCell.QrsPosition);

            if (neighbors.Count > 0)
            {
                var nextCell = neighbors[Random.Range(0, neighbors.Count)];
                MakeMove(nextCell);
            }
            else
            {
                Debug.Log("PLAYER WON!");
            }
        }

        OnMovedEvent?.Invoke();
    }

    private void MakeMove(Cell nextCell)
    {
        if (_currentCell)
        {
            _currentCell.ChangeState(Cell.CellState.Free);
        }

        _currentCell = nextCell;
        _currentCell.ChangeState(Cell.CellState.Player);

        transform.position = _currentCell.transform.position;
    }

    private void OnEnable()
    {
        MakeMove(_startCell);
    }
}
