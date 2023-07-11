using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform _rocket;

    private Vector3 startTransform = new Vector3();

    public void OnDrag(PointerEventData eventData)
    {
        startTransform.x = eventData.pointerCurrentRaycast.worldPosition.x;
        transform.position = startTransform;
    }

    private void Start()
    {
        startTransform = transform.position;
    }
}
