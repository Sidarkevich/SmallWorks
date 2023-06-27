using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private AudioMixerGroup _mixerOn;
    [SerializeField] private AudioMixerGroup _mixerOff;

    [SerializeField] private ToggleButton _soundToggle;
    [SerializeField] private ToggleButton _musicToggle;

    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _kickClip;
    [SerializeField] private AudioClip _goalClip;
    [SerializeField] private AudioClip _barbellClip;

    private void Awake()
    {
        var soundSettings = PlayerPrefs.GetInt("SoundSettings", 1);
        var value  = (soundSettings > 0)? true : false;
        ChangeState(value, _soundSource, "SoundSettings");
        _soundToggle.SetValue(value);

        var musicSettings = PlayerPrefs.GetInt("MusicSettings", 1);
        value = (musicSettings > 0)? true : false;
        ChangeState(value, _musicSource, "MusicSettings");
        _musicToggle.SetValue(value);
    }

    public void ChangeSoundState(bool value)
    {
        ChangeState(value, _soundSource, "SoundSettings");
    }

    public void ChangeMusicState(bool value)
    {
        ChangeState(value, _musicSource, "MusicSettings");
    }

    private void ChangeState(bool value, AudioSource source, string keyName)
    {
        var mixer = (value ? _mixerOn : _mixerOff);
        source.outputAudioMixerGroup = mixer;

        var newSettings = value ? 1 : 0;
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

    public void PlayBarbell()
    {
        _soundSource.clip = _barbellClip;
        _soundSource.Play();
    }
}