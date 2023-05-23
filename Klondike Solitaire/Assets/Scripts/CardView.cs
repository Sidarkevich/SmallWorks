using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    private Image _cardImage;

    private void Awake()
    {
        _cardImage = GetComponent<Image>();
    }

    public void Setup(DeckData deckData, CardData cardData)
    {
        _cardImage.material.SetTexture("_FrontTexture", cardData.FaceTexture);
        _cardImage.material.SetTexture("_BackTexture", deckData.BackTexture);
    }
}
