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

    private (int, int) GetTwoDifferentIndexes()
    {
        var result = (0, 0);
        var length = Enum.GetNames(typeof(CardData.CardSuit)).Length;
        var rnd = UnityEngine.Random.Range(0, length);

        if (rnd == length-1)
        {
            result.Item1 = length-1;
            result.Item2 = 0;
        }
        else
        {
            result.Item1 = rnd;
            result.Item2 = rnd + 1;
        }

        return result;
    }

    private List<CardData> GetPreparedDeck()
    {
        var luckyCards = new List<CardData>();
        var otherCards = new List<CardData>();
        var indexes = GetTwoDifferentIndexes();

        for (int i = 0; i < _deckData.Cards.Count; i++)
        {
            int suitIndex = (int)_deckData.Cards[i].Suit;

            if ((suitIndex == indexes.Item1) || (suitIndex == indexes.Item2))
            {
                luckyCards.Add(_deckData.Cards[i]);
            }
            else
            {
                otherCards.Add(_deckData.Cards[i]);
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
                    nextCard = luckyCards[0];
                    luckyCards.RemoveAt(0);
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

        preparedDeck.AddRange(otherCards);
        return preparedDeck;
    }
}
