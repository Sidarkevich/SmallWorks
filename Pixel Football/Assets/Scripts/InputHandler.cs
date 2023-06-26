using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private PlayerMovement _player;

    private Camera _camera;
    private Vector3 _lastTarget;

    public void OnDrag(PointerEventData eventData)
    {
        var target = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        
        if (_lastTarget != target)
        {
            _player.SetTarget(target);
            _lastTarget = target;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var target = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        
        if (_lastTarget != target)
        {
            _player.SetTarget(target);
            _lastTarget = target;
        }
    }

    private void Awake()
    {
        _camera = Camera.main;
    }
}
