using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private Sprite _filledSprite;
    
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

    private void OnMouseUpAsButton()
    {
        _cell.ChangeState(Cell.CellState.Filled);
    }

    private void OnStateChanged(Cell.CellState state)
    {
        if (state == Cell.CellState.Filled)
        {
            _renderer.sprite = _filledSprite;
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
