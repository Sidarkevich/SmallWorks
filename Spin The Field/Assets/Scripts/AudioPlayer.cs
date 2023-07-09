using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _soundStateChangedEvent;
    [SerializeField] private UnityEvent<bool> _musicStateChangedEvent;

    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioMixerGroup _mixerMute;

    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _kickClip;
    [SerializeField] private AudioClip _goalClip;

    private void Awake()
    {
        var soundSettings = PlayerPrefs.GetInt("SoundSettings", 0);
        var value  = (soundSettings > 0)? false : true;
        ChangeState(value, _soundSource, "SoundSettings", _soundStateChangedEvent);

        var musicSettings = PlayerPrefs.GetInt("MusicSettings", 0);
        value = (musicSettings > 0)? false : true;
        ChangeState(value, _musicSource, "MusicSettings", _musicStateChangedEvent);
    }

    public void ChangeSoundState(bool value)
    {
        ChangeState(value, _soundSource, "SoundSettings", _soundStateChangedEvent);
    }

    public void ChangeMusicState(bool value)
    {
        ChangeState(value, _musicSource, "MusicSettings", _musicStateChangedEvent);
    }

    private void ChangeState(bool value, AudioSource source, string keyName, UnityEvent<bool> unityEvent)
    {
        var mixer = (value ? _mixer : _mixerMute);
        source.outputAudioMixerGroup = mixer;
        unityEvent?.Invoke(value);

        var newSettings = value ? 0 : 1;
        PlayerPrefs.SetInt(keyName, newSettings);
        PlayerPrefs.Save();
    }

    public void PlayClick()
    {
        _soundSource.clip = _clickClip;
        _soundSource.Play();
    }

    public void PlayGoal()
    {
        _soundSource.clip = _goalClip;
        _soundSource.Play();
    }

    public void PlayKick()
    {
        _soundSource.clip = _kickClip;
        _soundSource.Play();
    }
}