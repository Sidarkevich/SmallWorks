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

    [SerializeField] private Toggle _soundToggle;

    [SerializeField] private AudioClip _clickClip;

    private bool _isLoading = true;
    private int _soundSettings;

    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 1);
        ChangeSoundState((_soundSettings > 0)? true : false);
    }

    private void Start()
    {
        _isLoading = false;
    }

    private void Play(AudioClip clip)
    {
        if (_isLoading)
        {
            return;
        }

        _soundSource.clip = clip;
        _soundSource.Play();
    }

    public void ChangeSoundState(bool value)
    {
        var mixer = (value ? _mixerOn : _mixerOff);

        _soundSource.outputAudioMixerGroup = mixer;
        _musicSource.outputAudioMixerGroup = mixer;

        _soundToggle.isOn = value;

        var newSettings = value ? 1 : 0;
        if (newSettings != _soundSettings)
        {
            PlayerPrefs.SetInt("SoundSettings", newSettings);
        }
    }

    public void PlayClick()
    {
        Play(_clickClip);
    }
}
