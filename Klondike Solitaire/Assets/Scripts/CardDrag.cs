using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    private RectTransform _rect;
    private Card _card;

    private Tableau _lastTableau;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_lastTableau)
        {
            var cards = GetComponentsInChildren<Card>();
            _lastTableau.RemoveCards(cards);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var cards = GetComponentsInChildren<Card>();

        if (_lastTableau)
        {
            if (_card.CurrentTableau)
            {
                _card.CurrentTableau.RemoveCards(cards);

                foreach (var card in cards)
                {
                    card.CurrentTableau = null;
                }
            }

            foreach (var card in cards)
            {
                _lastTableau.AddCard(card);
                card.CurrentTableau = _lastTableau;
            }
        }
        else if (_card.CurrentTableau)
        {
            _card.CurrentTableau.RemoveCards(cards);

            foreach (var card in cards)
            {
                card.CurrentTableau = null;
            }
        }
    }

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _card = GetComponent<Card>();

        _canvas = FindObjectOfType<Canvas>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var tableau = collider.GetComponent<Tableau>();
        if (tableau)
        {
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
            _lastTableau = null;
        }
    }
}
