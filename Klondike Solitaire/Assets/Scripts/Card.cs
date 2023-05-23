using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Tableau CurrentTableau;
    private CardData _data;
    private bool _isOpen;

    [SerializeField] private CardView _view;

    public void Init(DeckData deckData, CardData cardData)
    {
        _data = cardData;
        _view.Setup(deckData, cardData);
    }
}
