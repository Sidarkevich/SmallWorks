using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bot : MonoBehaviour
{
    public UnityEvent PlayerWonEvent;
    public UnityEvent PlayerLostEvent;

    [HideInInspector] public UnityEvent OnMovedEvent;

    [SerializeField] private Cell _startCell;
    [SerializeField] private CellMap _map;

    private Cell _currentCell;
    private bool _firstLoad = true;

    public void Move(int moves)
    {
        var paths = _map.GetFreeDirections(_currentCell.QrsPosition);

        if (paths.Count > 0)
        {
            paths.Shuffle();
            paths.Sort((a, b) => a.Count.CompareTo(b.Count));
            var direction = paths[0];
            
            if (direction[0].State == Cell.CellState.Border)
            {
                PlayerLostEvent?.Invoke();
                MakeMove(direction[0]);
                return;
            }

            MakeMove(direction[0]);
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
                PlayerWonEvent?.Invoke();
            }
        }

        OnMovedEvent?.Invoke();
    }

    private void MakeMove(Cell nextCell)
    {
        if (_currentCell)
        {
            _currentCell.ChangeState(Cell.CellState.Free, false);
        }

        _currentCell = nextCell;
        _currentCell.ChangeState(Cell.CellState.Player, false);

        transform.position = _currentCell.transform.position;
    }

    private void OnEnable()
    {
        if (_firstLoad)
        {
            _firstLoad = false;
            return;
        }

        _map.ClearMap();
        MakeMove(_startCell);
        _map.RandomFill();
    }

    public void EnableAfterLoad()
    {
        OnEnable();
    }
}
