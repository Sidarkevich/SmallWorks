using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private Sprite _filledSprite;
    [SerializeField] private Sprite _emptySprite;
    
    private Cell _cell;
    private SpriteRenderer _renderer;
    private Collider2D _collider;

    private void Awake()
    {
        _cell = GetComponent<Cell>();
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        _cell.StateChangedEvent.AddListener(OnStateChanged);
    }

    private void OnEnable()
    {
        OnUnlocked();
    }

    private void OnMouseUpAsButton()
    {
        _cell.ChangeState(Cell.CellState.Filled, true);
    }

    private void OnStateChanged(Cell.CellState state, bool byPlayer)
    {
        if (state == Cell.CellState.Filled)
        {
            _renderer.sprite = _filledSprite;
        }
        else if (state == Cell.CellState.Free)
        {
            _renderer.sprite = _emptySprite;
        }
    }

    private void OnLocked()
    {
        _collider.enabled = false;
    }

    private void OnUnlocked()
    {
        _collider.enabled = true;
    }
}
