using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMap : MonoBehaviour
{
    public Cell StartCell => startCell;
    
    [SerializeField] private Vector3[] directionVectors;
    [SerializeField] private Vector2Int filledCount;
    [SerializeField] private Cell startCell;
    
    private List<Cell> _cells;

    private void Awake()
    {
        _cells = new List<Cell>(GetComponentsInChildren<Cell>());
    }

    public void ClearMap()
    {
        /*var playable = _cells.FindAll((x) => ((x.State == Cell.CellState.Filled) || (x.State == Cell.CellState.Player)));

        foreach (var cell in playable)
        {
            cell.ChangeState(Cell.CellState.Free, false);
        }*/
    }
    
    public List<Cell> GetFreeNeighbors(Vector3 qrs)
    {
        var result = new List<Cell>();

        foreach (var direction in directionVectors)
        {
            var neighbor = GetCell(qrs + direction);

            if (neighbor)
            {
                if (neighbor.IsFree)
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

        foreach (var direction in directionVectors)
        {
            var directionPath = new List<Cell>();
            var position = qrs;

            while (true)
            {
                position += direction;

                var nextCell = GetCell(position);
                if (nextCell)
                {
                    /*if (nextCell.State == Cell.CellState.Free)
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
                    }*/
                }
                else
                {
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
            if (cell.QRS == qrs)
            {
                return cell;
            }
        }

        return null;
    }
}