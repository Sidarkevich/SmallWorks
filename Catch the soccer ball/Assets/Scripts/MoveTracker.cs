using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTracker : MonoBehaviour
{
    public UnityEvent<int> PlayerMovedEvent;
    public UnityEvent BotMovedEvent;

    [SerializeField] private Bot _bot;

    public int Moves
    {
        get => _moves;
        set
        {
            _moves = value;
            
            if (_moves > 0)
                PlayerMovedEvent?.Invoke(_moves);
        }
    }

    private int _moves;
    private List<Cell> _cells = new List<Cell>();

    private void Start()
    {
        _cells = new List<Cell>(GetComponentsInChildren<Cell>());

        foreach (var cell in _cells)
        {
            if (cell.State == Cell.CellState.Border)
            {
                continue;
            }

            cell.StateChangedEvent.AddListener(OnStateChanged);
            PlayerMovedEvent.AddListener(cell.Lock);
            BotMovedEvent.AddListener(cell.Unlock);
        }

        PlayerMovedEvent.AddListener(_bot.Move);
        _bot.MovedEvent.AddListener(() => BotMovedEvent?.Invoke());
    }

    private void OnStateChanged(Cell.CellState state, bool byPlayer)
    {
        if ((state == Cell.CellState.Filled) && (byPlayer))
        {
            Moves++;
        }
    }

    private void OnEnable()
    {
        Moves = 0;
    }
}
