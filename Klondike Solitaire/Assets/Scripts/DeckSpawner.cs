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
    }
}
