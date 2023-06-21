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

    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _scoreClip;

    private int _soundSettings;

    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 1);
        ChangeSoundState((_soundSettings > 0)? true : false);
        _soundToggle.SetValue((_soundSettings > 0)? true : false);
    }

    private void Play(AudioClip clip)
    {
        _soundSource.clip = clip;
        _soundSource.Play();
    }

    public void ChangeSoundState(bool value)
    {
        var mixer = (value ? _mixerOn : _mixerOff);

        _soundSource.outputAudioMixerGroup = mixer;
        _musicSource.outputAudioMixerGroup = mixer;

        var newSettings = value ? 1 : 0;
        if (newSettings != _soundSettings)
        {
            PlayerPrefs.SetInt("SoundSettings", newSettings);
            PlayerPrefs.Save();
        }
    }

    public void PlayClick()
    {
        Play(_clickClip);
    }

    public void PlayScore()
    {
        Play(_scoreClip);
    }
}