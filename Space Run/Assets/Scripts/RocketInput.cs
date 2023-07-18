using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform _rocket;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _leftBorder;

    private Vector3 _newPosition = new Vector3();
    private Vector3 _startPosition;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.isValid)
        {
            _newPosition.x = eventData.pointerCurrentRaycast.worldPosition.x;
            _newPosition.x = (_newPosition.x > 0 ? Mathf.Min(_newPosition.x, _rightBorder.position.x) : Mathf.Max(_newPosition.x, _leftBorder.position.x));

            transform.position = _newPosition;
        }
    }

    private void Start()
    {
        _newPosition = transform.position;
    }

    private void Awake()
    {
        _startPosition = transform.position; 
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
    }
}
