using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Forms a deck and distributes cards between tableaus.
/// </summary>
public class Dispenser : MonoBehaviour
{
    [SerializeField] DeckSpawner _spawner;
    [SerializeField] Tableau[] _tableaus;
    [SerializeField] private DeckData _deckData;

    private List<Card> _deck;

    private void Start()
    {
        var preparedDeck = GetPreparedDeck();
        _deck = _spawner.SpawnDeck(preparedDeck, _deckData);
        
        for (int i = 0; i < _tableaus.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                var card = _deck[0];
                _deck.Remove(card);
                _tableaus[i].AddCard(card);

                if (j == i)
                {
                    card.Open();
                }
            }
        }
    }

    private List<CardData> GetPreparedDeck()
    {
        var luckyCards = new List<CardData>();                                      // Cards that guarantee an advantage
        var deck = new List<CardData>(_deckData.Cards);
        deck.Shuffle();
        var otherCards = new List<CardData>(deck);

        var minValue = GetMinDeckValue();                                           // Max and Min values of the deck (f.e. Ace - 1, King - 13)
        var maxValue = GetMaxDeckValue();

        for (var i = minValue; i <= maxValue; i++)                                  // Collect 2 win combination of different colors
        {
            foreach (var cardData in deck)
            {
                if ((cardData.Value == i) && ((int)cardData.Suit % 2 == 0))
                {
                    otherCards.Remove(cardData);
                    luckyCards.Add(cardData);
                    break;
                }
            }

            foreach (var cardData in deck)
            {
                if ((cardData.Value == i) && ((int)cardData.Suit % 2 != 0))
                {
                    otherCards.Remove(cardData);
                    luckyCards.Add(cardData);
                    break;
                }
            }
        }

        luckyCards.Shuffle();
        otherCards.Shuffle();

        var preparedDeck = new List<CardData>();                                       // Fill the deck with ordinary cards
        for (int i = 0; i < _tableaus.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                CardData nextCard;

                if (j == i)
                {
                    nextCard = null;
                }
                else
                {
                    nextCard = otherCards[0];
                    otherCards.RemoveAt(0);
                }

                preparedDeck.Add(nextCard);
            }
        }
        otherCards.AddRange(luckyCards);
        otherCards.Shuffle();

        for (int i = 0; i < preparedDeck.Count; i++)                                    // Fill in the missing items
        {
            if (preparedDeck[i] == null)
            {
                preparedDeck[i] = otherCards[Random.Range(0, otherCards.Count-1)];
                otherCards.Remove(preparedDeck[i]);
            }
        }

        preparedDeck.AddRange(otherCards);
        return preparedDeck;
    }

    private int GetMinDeckValue()
    {
        var minValue = _deckData.Cards[0];
        foreach (var data in _deckData.Cards)
        {
            if (data.Value < minValue.Value)
            {
                minValue = data;
            }
        }

        return minValue.Value;
    }

    private int GetMaxDeckValue()
    {
        var maxValue = _deckData.Cards[0];
        foreach (var data in _deckData.Cards)
        {
            if (data.Value > maxValue.Value)
            {
                maxValue = data;
            }
        }

        return maxValue.Value;
    }
}
