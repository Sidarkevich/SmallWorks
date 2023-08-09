using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spot : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private ScoreHandler _score;
    
    public void Setup(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var comet = collision.GetComponent<Comet>();

        if (comet)
        {
            if (comet.CurrentSprite == _image.sprite)
            {
                
            }
            else
            {
                _score.Loss();
            }
        }
    }
}
