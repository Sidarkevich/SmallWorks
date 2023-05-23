using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    private RectTransform _rect;
    private Card _card;

    private Tableau _lastTableau;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_lastTableau)
        {
            _lastTableau.RemoveCard(_card);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_lastTableau)
        {
            if (_card.CurrentTableau)
            {
                _card.CurrentTableau.RemoveCard(_card);
                _card.CurrentTableau = null;
            }

            _lastTableau.AddCard(_card);
            _card.CurrentTableau = _lastTableau;
        }
        else if (_card.CurrentTableau)
        {
            _card.CurrentTableau.RemoveCard(_card);
            _card.CurrentTableau = null;
        }
    }

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _card = GetComponent<Card>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var tableau = collider.GetComponent<Tableau>();
        if (tableau)
        {
            Debug.Log($"In {tableau.gameObject.name}");
            _lastTableau = tableau;
            return;
        }

        var cardDrag = collider.GetComponent<CardDrag>();
        if ((cardDrag) && (_card.CurrentTableau))
        {
            cardDrag._lastTableau = _card.CurrentTableau;
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var tableau = collider.GetComponent<Tableau>();

        if ((tableau) && (_lastTableau == tableau))
        {
            Debug.Log($"Out of tableau");
            _lastTableau = null;
        }
    }
}
