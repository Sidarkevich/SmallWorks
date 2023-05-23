using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Deck")]
public class DeckData : ScriptableObject
{
    public List<CardData> Cards => _cards;
    public Sprite BackSprite => _backSprite;

    [SerializeField] private List<CardData> _cards;
    [SerializeField] private Sprite _backSprite;
}
