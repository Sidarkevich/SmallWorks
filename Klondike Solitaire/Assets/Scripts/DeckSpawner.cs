using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSpawner : MonoBehaviour
{
    [SerializeField] private DeckData _deckData;
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private Tableau[] _tableaus;

    private List<Card> _cards = new List<Card>();

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
            card.GetComponent<RectTransform>().SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(0, 180, 0));
            card.Init(_deckData, cardData);

            _cards.Add(card);
        }

        for (int i = 0; i < _tableaus.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                var card = _cards[0];
                _cards.Remove(card);

                Debug.Log("i: " + i);

                _tableaus[i].AddCard(card);
            }
        }
    }
}
