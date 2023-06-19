using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Goalkeeper _keeper;

    public void OnPointerDown(PointerEventData eventData)
    {
        var point = Camera.main.ScreenToWorldPoint(eventData.position);

        if (point.x > 0)
        {
            _keeper.Move(Vector3.right);
        }
        else
        {
            _keeper.Move(Vector3.left);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _keeper.Stop();
    }

    private void OnEnable()
    {
        _keeper.Stop();
    }
}
