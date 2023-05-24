using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

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
        var luckyCards = new List<CardData>();
        var deck = new List<CardData>(_deckData.Cards);
        deck.Shuffle();
        var otherCards = new List<CardData>(deck);

        var minValue = GetMinDeckValue();
        var maxValue = GetMaxDeckValue();

        for (var i = minValue; i <= maxValue; i++)
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

        var preparedDeck = new List<CardData>();
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

        for (int i = 0; i < preparedDeck.Count; i++)
        {
            if (preparedDeck[i] == null)
            {
                preparedDeck[i] = otherCards[UnityEngine.Random.Range(0, otherCards.Count-1)];
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
