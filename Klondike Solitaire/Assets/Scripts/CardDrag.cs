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
        _lastTableau = null;
        _rect.SetParent(_canvas.transform);
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
            }

            foreach (var card in cards)
            {
                _lastTableau.AddCard(card);
            }
        }
        else
        {
            _card.CurrentTableau.UpdateView();
        }
    }

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _card = GetComponent<Card>();

        _canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var tableau = collider.GetComponent<Tableau>();
        if (tableau)
        {
            if (tableau.CanBeAdded(_card))
            {
                _lastTableau = tableau;
                return;
            }
        }

        var card = collider.GetComponent<Card>();
        if ((card) && (card.CurrentTableau))
        {
            if (card.CurrentTableau.CanBeAdded(_card))
            {
                _lastTableau = card.CurrentTableau;
                return;
            }
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
