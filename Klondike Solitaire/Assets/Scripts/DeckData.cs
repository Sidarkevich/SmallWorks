using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Deck")]
public class DeckData : ScriptableObject
{
    public List<CardData> Cards => _cards;
    [SerializeField] private List<CardData> _cards;
}
