using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSpawner : MonoBehaviour
{
    [SerializeField] private DeckData _deckData;
    [SerializeField] private Card _cardPrefab;

    public List<Card> SpawnDeck()
    {
        var cards = new List<Card>();
        var deck = new List<CardData>(_deckData.Cards);
        deck.Shuffle();

        foreach (var cardData in deck)
        {
            var card = Instantiate(_cardPrefab, gameObject.GetComponent<RectTransform>());
            card.GetComponent<RectTransform>().SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            card.Init(_deckData, cardData);

            cards.Add(card);
        }

        return cards;
    }
}
