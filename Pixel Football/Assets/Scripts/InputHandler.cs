using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler, IPointerEnterHandler
{
    [SerializeField] private CharacterMovement _player;

    private Camera _camera;
    private bool _isDragging;

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDragging)
        {
            return;
        }

        var target = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        _player.SetTarget(target);     
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDragging = true;

        var target = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        _player.SetTarget(target);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isDragging = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isDragging = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }

    private void Awake()
    {
        _camera = Camera.main;
    }
}
