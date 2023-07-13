using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform _rocket;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _leftBorder;

    private Vector3 newPosition = new Vector3();

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.isValid)
        {
            newPosition.x = eventData.pointerCurrentRaycast.worldPosition.x;
            newPosition.x = (newPosition.x > 0 ? Mathf.Min(newPosition.x, _rightBorder.position.x) : Mathf.Max(newPosition.x, _leftBorder.position.x));

            transform.position = newPosition;
        }
    }

    private void Start()
    {
        newPosition = transform.position;
    }
}
