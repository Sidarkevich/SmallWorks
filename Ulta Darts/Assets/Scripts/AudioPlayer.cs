using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _soundStateChangedEvent;
    [SerializeField] private UnityEvent<bool> _musicStateChangedEvent;

    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private AudioMixerGroup _mixerOn;
    [SerializeField] private AudioMixerGroup _mixerOff;

    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _hitClip;

    private int _soundSettings;
    private int _musicSettings;

    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 0);
        MuteSound((_soundSettings > 0)? true : false);

        _musicSettings = PlayerPrefs.GetInt("MusicSettings", 0);
        MuteMusic((_musicSettings > 0)? true : false);
    }

    public void MuteSound(bool value)
    {
        ChangeState(value, _soundSource, "SoundSettings", _soundStateChangedEvent);
    }

    public void MuteMusic(bool value)
    {
        ChangeState(value, _musicSource, "MusicSettings", _musicStateChangedEvent);
    }

    private void ChangeState(bool value, AudioSource source, string keyName, UnityEvent<bool> unityEvent)
    {
        var mixer = (value ? _mixerOff : _mixerOn);
        source.outputAudioMixerGroup = mixer;

        var newSettings = value ? 1 : 0;
        PlayerPrefs.SetInt(keyName, newSettings);
        PlayerPrefs.Save();

        unityEvent?.Invoke(value);
    }

    public void PlayClick()
    {
        _soundSource.volume = 0.5f;
        _soundSource.clip = _clickClip;
        _soundSource.Play();
    }

    public void PlayScore()
    {
        _soundSource.volume = 0.05f;
        _soundSource.clip = _hitClip;
        _soundSource.Play();
    }
}
