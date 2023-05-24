using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for displaying the map on the screen.
/// </summary>
public class CardView : MonoBehaviour
{
    private Image _cardImage;

    [SerializeField] private Shader _cardShader;
    [SerializeField] private Animation _animation;

    private void Awake()
    {
        _cardImage = GetComponent<Image>();
    }

    public void Setup(DeckData deckData, CardData cardData)
    {
        var width = (int)cardData.FaceSprite.rect.width;
        var height = (int)cardData.FaceSprite.rect.height;

        var pixelData = cardData.FaceSprite.texture.GetPixels((int)cardData.FaceSprite.rect.x, (int)cardData.FaceSprite.rect.y, width, height);
        var newTex = new Texture2D(width, height);
        newTex.SetPixels(pixelData);
        newTex.Apply();

        var material = new Material(_cardShader);
        _cardImage.material = material;
        _cardImage.material.SetTexture("_FrontTexture", newTex);
        _cardImage.material.SetTexture("_BackTexture", deckData.BackTexture);
    }

    public void Open()
    {
        _animation.Play();
    }
}
