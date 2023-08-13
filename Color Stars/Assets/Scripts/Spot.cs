using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Spot : MonoBehaviour
{
    [HideInInspector] public UnityEvent CollectedEvent = new UnityEvent();

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
                CollectedEvent?.Invoke();
            }
            else
            {
                _score.Loss();
            }
        }
    }
}
