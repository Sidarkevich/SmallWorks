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

    public List<Cell> GetFreeNeighbors(Cell cell)
    {
        var result = new List<Cell>();

        foreach (var direction in _directionVectors)
        {
            var neighbor = GetCell(cell.QrsPosition + direction);

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
