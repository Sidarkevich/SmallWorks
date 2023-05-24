using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSpawner : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;

    public List<Card> SpawnDeck(List<CardData> cardsData, DeckData deckData)
    {
        var cards = new List<Card>();

        foreach (var cardData in cardsData)
        {
            var card = Instantiate(_cardPrefab, gameObject.GetComponent<RectTransform>());
            card.GetComponent<RectTransform>().SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            card.Init(deckData, cardData);

            cards.Add(card);
        }

        return cards;
    }
}
