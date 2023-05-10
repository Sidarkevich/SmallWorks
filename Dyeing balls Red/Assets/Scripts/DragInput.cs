using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private GameTracker _tracker;

    private bool _isInputActive;

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isInputActive)
        {
            return;
        }

        if (eventData.pointerCurrentRaycast.isValid)
        {
            _ball.MoveTo(eventData.pointerCurrentRaycast.worldPosition);
        }
    }

    private void Start()
    {
        _tracker.GameStartEvent.AddListener(OnGameStarted);
        _tracker.GameEndEvent.AddListener(OnGameFinished);
    }

    private void OnGameStarted()
    {
        _collider.enabled = true;
        _isInputActive = true;
    }

    private void OnGameFinished()
    {
        _collider.enabled = false;
        _isInputActive = false;
    }
}
