using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _soundStateChangedEvent;

    [SerializeField] private AudioSource _uiSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _gameSource;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioMixerGroup _mixerMuted;

    private int _soundSettings;

    public void PlaySoundClip(AudioClip clip)
    {
        _gameSource.clip = clip;
        _gameSource.Play();
    }

    public void PlayClick()
    {
        _uiSource.Play();
    }

    public void MuteSound(bool value)
    {
        var mixer = (value ? _mixerMuted : _mixer);
        _uiSource.outputAudioMixerGroup = mixer;
        _musicSource.outputAudioMixerGroup = mixer;
        _gameSource.outputAudioMixerGroup = mixer;

        var newSettings = value ? 1 : 0;
        PlayerPrefs.SetInt("SoundSettings", newSettings);
        PlayerPrefs.Save();

        _soundStateChangedEvent?.Invoke(value);
    }
    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 0);
        MuteSound((_soundSettings > 0) ? true : false);
    }
}