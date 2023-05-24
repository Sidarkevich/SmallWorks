using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField] DeckSpawner _spawner;
    [SerializeField] Tableau[] _tableaus;

    private List<Card> _deck;

    private void Start()
    {
        _deck = _spawner.SpawnDeck();
        
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
}
