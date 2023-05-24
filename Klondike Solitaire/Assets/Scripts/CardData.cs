using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data stored about the game card.
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
public class CardData : ScriptableObject
{
    public enum CardSuit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }

    public CardSuit Suit => _suit;
    public byte Value => _value;
    public Sprite FaceSprite => _faceSprite;

    [SerializeField] private CardSuit _suit;
    [SerializeField] private byte _value;
    [SerializeField] private Sprite _faceSprite;
}
