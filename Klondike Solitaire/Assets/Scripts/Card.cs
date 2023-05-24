using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool IsOpen => _isOpen;
    public CardData Data => _data;

    public Tableau CurrentTableau;



    private CardData _data;
    private bool _isOpen;

    [SerializeField] private CardView _view;

    public void Init(DeckData deckData, CardData cardData)
    {
        _data = cardData;
        _view.Setup(deckData, cardData);
    }

    public void Open()
    {
        _isOpen = true;
        _view.Open();
    }
}
