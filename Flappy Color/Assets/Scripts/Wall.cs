using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Wall : MonoBehaviour
{
    [SerializeField] private ColorHandler _color;
    [SerializeField] private AudioClip _swapClip;

    private AudioPlayer _audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();

        if (ball)
        {
            ball.Color.ChangeColor(_color.ColorIndex);
            _audio.PlaySoundClip(_swapClip);
        }
    }

    private void OnEnable()
    {
        _color.SetRandomColor();
    }

    private void Awake()
    {
        _audio = FindObjectOfType<AudioPlayer>();
    }
}
