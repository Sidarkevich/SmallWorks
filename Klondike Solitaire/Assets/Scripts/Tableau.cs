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
    }

    public void RemoveCard(Card card)
    {
        _cards.Remove(card);
        _view.SetupView(_cards);   
    }
}
