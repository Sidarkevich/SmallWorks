using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Block : MonoBehaviour
{
    [SerializeField] private ColorHandler _color;
    [SerializeField] private int _increaseValue;
    [SerializeField] private AudioClip _scoreClip;
    [SerializeField] private AudioClip _hitClip;

    public ColorHandler Color => _color;

    private AudioPlayer _audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();

        if (ball)
        {
            if (ball.Color.ColorIndex == _color.ColorIndex)
            {
                ball.Score.IncreaseScore(_increaseValue);
                _audio.PlaySoundClip(_scoreClip);
            }
            else
            {
                ball.Score.Loss();
                _audio.PlaySoundClip(_hitClip);
            }
        }
    }

    private void Awake()
    {
        _audio = FindObjectOfType<AudioPlayer>();
    }
}
