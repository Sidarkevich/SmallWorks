using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public abstract class Element : MonoBehaviour
{
    [SerializeField] private UnityEvent _effectedEvent;
    [SerializeField] private AudioClip _effectClip;

    protected ScoreHandler _score;
    protected ObjectPool _pool;
    protected SpeedHandler _speed;
    protected AudioPlayer _audio;

    public void Init(ScoreHandler score, ObjectPool pool, SpeedHandler speed, AudioPlayer audio)
    {
        _score = score;
        _pool = pool;
        _speed = speed;
        _audio = audio;
    }

    public void Init(ScoreHandler score, AudioPlayer audio)
    {
        _score = score;
        _audio = audio;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var rocket = collider.GetComponent<RocketMovement>();

        if (rocket)
        {
            Effect();
            _audio.PlaySoundClip(_effectClip);
            _effectedEvent?.Invoke();
        }
    }

    protected abstract void Effect();
}
