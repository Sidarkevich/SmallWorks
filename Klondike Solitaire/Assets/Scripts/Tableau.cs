using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    [SerializeField] private TableauView _view;
    private List<Card> _cards = new List<Card>();

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
