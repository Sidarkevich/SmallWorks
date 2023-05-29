using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMap : MonoBehaviour
{
    [SerializeField] private Vector3[] _directionVectors;
    private Cell[] _cells;

    private void Awake()
    {
        _cells = GetComponentsInChildren<Cell>();
    }

    public List<Cell> GetFreeNeighbors(Vector3 qrs)
    {
        var result = new List<Cell>();

        foreach (var direction in _directionVectors)
        {
            var neighbor = GetCell(qrs + direction);

            if (neighbor)
            {
                if (neighbor.State == Cell.CellState.Free)
                {
                    result.Add(neighbor);
                }
            }
        }

        return result;
    }

    public List<List<Cell>> GetFreeDirections(Vector3 qrs)
    {
        var result = new List<List<Cell>>();

        foreach (var direction in _directionVectors)
        {
            var directionPath = new List<Cell>();
            var position = qrs;

            while (true)
            {
                position += direction;

                var nextCell = GetCell(position);
                if (nextCell)
                {
                    if (nextCell.State == Cell.CellState.Free)
                    {
                        directionPath.Add(nextCell);
                    }
                    else if (nextCell.State == Cell.CellState.Border)
                    {
                        directionPath.Add(nextCell);
                        result.Add(directionPath);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Debug.Log("SomethingWrong!");
                    break;
                }
            }
        }

        return result;
    }

    private Cell GetCell(Vector3 qrs)
    {
        foreach (var cell in _cells)
        {
            if (cell.QrsPosition == qrs)
            {
                return cell;
            }
        }

        return null;
    }
}
