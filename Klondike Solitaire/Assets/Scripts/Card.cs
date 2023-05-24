using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardView _view;
    [SerializeField] private CardDrag _drag;

    public bool IsOpen => _isOpen;
    public CardData Data => _data;
    public Tableau CurrentTableau => _currentTableau;
    // {
    //     get => _currentTableau;
    //     set
    //     {
    //         _currentTableau = value;
    //     }
    // }

    private Tableau _currentTableau;
    private CardData _data;
    private bool _isOpen;

    public void Init(DeckData deckData, CardData cardData)
    {
        _data = cardData;
        _view.Setup(deckData, cardData);
    }

    public void Open()
    {
        _isOpen = true;
        _drag.enabled = true;
        _view.Open();
    }

    public void ChangeTableau(Tableau tableau)
    {
        _currentTableau = tableau;
    }
}
