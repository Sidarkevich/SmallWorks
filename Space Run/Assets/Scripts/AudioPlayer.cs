using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _soundStateChangedEvent;

    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioMixerGroup _mixerMuted;

    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private AudioClip _scoreClip;

    private int _soundSettings;

    public void PlayClick()
    {
        _soundSource.clip = _clickClip;
        _soundSource.Play();
    }

    public void PlayHit()
    {
        _soundSource.clip = _hitClip;
        _soundSource.Play();
    }

    public void PlayScore()
    {
        _soundSource.clip = _scoreClip;
        _soundSource.Play();
    }

    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 0);
        MuteSound((_soundSettings > 0)? true : false);
    }

    public void MuteSound(bool value)
    {
        var mixer = (value ? _mixerMuted : _mixer);
        _soundSource.outputAudioMixerGroup = mixer;
        _musicSource.outputAudioMixerGroup = mixer;

        var newSettings = value ? 1 : 0;
        PlayerPrefs.SetInt("SoundSettings", newSettings);
        PlayerPrefs.Save();

        _soundStateChangedEvent?.Invoke(value);
    }
}