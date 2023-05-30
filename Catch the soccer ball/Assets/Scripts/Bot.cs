using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Bot : MonoBehaviour
{
    public UnityEvent PlayerWonEvent;
    public UnityEvent PlayerLostEvent;

    [HideInInspector] public UnityEvent MovedEvent;

    [SerializeField] private CellMap _map;

    private Cell _currentCell;
    private float _moveSpeed = 0.5f;

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
                transform.DOMove(direction[0].transform.position, _moveSpeed).OnComplete(() => { Moved(direction[0]); MovedEvent?.Invoke();});
                return;
            }

            transform.DOMove(direction[0].transform.position, _moveSpeed).OnComplete(() => { Moved(direction[0]); MovedEvent?.Invoke();});
        }
        else
        {
            var neighbors = _map.GetFreeNeighbors(_currentCell.QrsPosition);

            if (neighbors.Count > 0)
            {
                var nextCell = neighbors[Random.Range(0, neighbors.Count)];
                transform.DOMove(nextCell.transform.position, _moveSpeed).OnComplete(() => { Moved(nextCell); MovedEvent?.Invoke();});
            }
            else
            {
                PlayerWonEvent?.Invoke();
            }
        }

        // MovedEvent?.Invoke();
    }

    public void Moved(Cell nextCell)
    {
        if (_currentCell)
        {
            _currentCell.ChangeState(Cell.CellState.Free, false);
        }

        _currentCell = nextCell;
        _currentCell.ChangeState(Cell.CellState.Player, false);

        transform.position = _currentCell.transform.position;
    }
}
