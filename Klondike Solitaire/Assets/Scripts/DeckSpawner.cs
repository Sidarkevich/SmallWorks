using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSpawner : MonoBehaviour
{
    [SerializeField] private DeckData _deckData;
    [SerializeField] private Card _cardPrefab;

    private void Start()
    {
        SpawnDeck();
    }

    public void SpawnDeck()
    {
        var deck = new List<CardData>(_deckData.Cards);
        deck.Shuffle();

        foreach (var cardData in deck)
        {
            var card = Instantiate(_cardPrefab, gameObject.GetComponent<RectTransform>());
            card.GetComponent<RectTransform>().SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            card.Init(_deckData, cardData);
        }
    }
}
