using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private PlayerMovement _player;

    private Camera _camera;

    public void OnDrag(PointerEventData eventData)
    {
        var target = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        _player.SetTarget(target);
    }

    private void Awake()
    {
        _camera = Camera.main;
    }
}
