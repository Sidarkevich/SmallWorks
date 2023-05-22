using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    [SerializeField] private TableauView _view;
    private List<Card> _cards = new List<Card>();

    public void AddCard(Card newCard)
    {
        _cards.Add(newCard);
        _view.SetupView(_cards);
    }
}
