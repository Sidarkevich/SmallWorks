using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    [SerializeField] private byte _kingValue;
    [SerializeField] private TableauView _view;
    private List<Card> _cards = new List<Card>();

    public void UpdateView()
    {
        _view.SetupView(_cards);
    }

    public bool CanBeAdded(Card card)
    {
        if (_cards.Count == 0)
        {
            if ((card.Data.Value == _kingValue) || (!card.IsOpen))
            {
                return true;
            }

            return false;
        }

        var lastCard = _cards[_cards.Count-1];
        bool isOdd = ((lastCard.Data.Value % 2) == 0 ? false : true); 

        if (card.Data.Value == lastCard.Data.Value-1)
        {
            return true;
        }

        return false;
    }

    public void AddCard(Card card)
    {
        card.ChangeTableau(this);
        _cards.Add(card);
        _view.SetupView(_cards);
        //CheckCount();
    }

    public void RemoveCard(Card card)
    {
        card.ChangeTableau(null);
        _cards.Remove(card);
        _view.SetupView(_cards);
        CheckCount(); 
    }

    public void RemoveCards(Card[] cards)
    {
        foreach (var card in cards)
        {
            card.ChangeTableau(null);
            _cards.Remove(card);
        }

        _view.SetupView(_cards);
        CheckCount();
    }

    private void CheckCount()
    {
        if (_cards.Count > 0)
        {
            var lastCard = _cards[_cards.Count-1];

            if (!lastCard.IsOpen)
            {
                lastCard.Open();
            }
        }
    }
}
