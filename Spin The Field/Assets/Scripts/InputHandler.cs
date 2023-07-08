using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform _levelRoot;
    [SerializeField] private string _axis;
    [SerializeField] private float _rotationSpeed;

    private float _starDragXPos;

    public void OnDrag(PointerEventData eventData)
    {
        _levelRoot.Rotate(Vector3.forward, Input.GetAxis(_axis) * _rotationSpeed);
    }
}
