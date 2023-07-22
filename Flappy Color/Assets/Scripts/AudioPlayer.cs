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

    private int _soundSettings;

    public void PlaySoundClip(AudioClip clip)
    {
        _soundSource.clip = clip;
        _soundSource.Play();
    }

    public void PlayClick()
    {
        _soundSource.clip = _clickClip;
        _soundSource.Play();
    }

    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 0);
        MuteSound((_soundSettings > 0) ? true : false);
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