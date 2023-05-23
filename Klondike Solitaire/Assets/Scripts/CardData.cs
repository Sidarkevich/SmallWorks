using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
public class CardData : ScriptableObject
{
    public enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public CardSuit Suit => _suit;
    public byte Value => _value;
    public Texture2D FaceTexture => _faceTexture;

    [SerializeField] private CardSuit _suit;
    [SerializeField] private byte _value;
    [SerializeField] private Texture2D _faceTexture;
}
