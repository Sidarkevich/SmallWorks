using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    [SerializeField] private byte _kingValue;
    [SerializeField] private TableauView _view;
    private List<Card> _cards = new List<Card>();

    public bool CanBeAdded(Card card)
    {
        if (_cards.Count == 0)
        {
            if ((card.Data.Value == _kingValue) || (!card.IsOpen))
            {
                return true;
            }
        }

        var lastCard = _cards[_cards.Count-1];
        if (card.Data.Value == lastCard.Data.Value-1)
        {
            return true;
        }

        return false;
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
        _view.SetupView(_cards);
        //CheckCount();
    }

    public void RemoveCard(Card card)
    {
        _cards.Remove(card);
        _view.SetupView(_cards);
        CheckCount(); 
    }

    public void RemoveCards(Card[] cards)
    {
        foreach (var card in cards)
        {
            _cards.Remove(card);
        }

        _view.SetupView(_cards);
        CheckCount();
    }

    private void CheckCount()
    {
        if (_cards.Count == 1)
        {
            _cards[0].Open();
        }
    }
}
