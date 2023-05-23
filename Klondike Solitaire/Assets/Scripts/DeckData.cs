using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Deck")]
public class DeckData : ScriptableObject
{
    public List<CardData> Cards => _cards;
    public Texture2D BackTexture => _backTexture;

    [SerializeField] private List<CardData> _cards;
    [SerializeField] private Texture2D _backTexture;
}
