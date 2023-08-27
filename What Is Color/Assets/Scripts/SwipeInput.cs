using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private ColorsHandler _colorsHandler;
    [SerializeField] private float _moveTime;

    private Vector3 _startPosition;
    private bool _isDragging;

    private Vector3 _startSwipePosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startSwipePosition = eventData.pointerCurrentRaycast.worldPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DetectDirection(_startSwipePosition, eventData.pointerCurrentRaycast.worldPosition);
    }

    public void Setup()
    {
        _isDragging = false;
        _rigidBody.MovePosition(_startPosition);
    }

    private void Start()
    {
        _startPosition = _rigidBody.transform.position;
    }

    private void DetectDirection(Vector3 startPos, Vector3 endPos)
    {
        var xValue = Mathf.Abs(endPos.x - startPos.x);
        var yValue = Mathf.Abs(endPos.y - startPos.y);

        if (xValue > yValue)
        {
            if (endPos.x > startPos.x)
            {
                
            }
            else
            {
                
            }
        }
        else
        {
            if (endPos.y > startPos.y)
            {
                
            }
            else
            {
                
            }
        }
    }
}
