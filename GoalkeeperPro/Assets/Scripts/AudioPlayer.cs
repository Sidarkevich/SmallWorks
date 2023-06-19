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
    [SerializeField] private AudioClip _GoalClip;
    [SerializeField] private AudioClip _KeepClip;

    private int _soundSettings;
    private int _musicSettings;

    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 1);
        _soundToggle.ChangeValue((_soundSettings > 0)? true : false);
        ChangeSoundState((_soundSettings > 0)? true : false);

        _musicSettings = PlayerPrefs.GetInt("MusicSettings", 1);
        _musicToggle.ChangeValue((_musicSettings > 0)? true : false);
        ChangeMusicState((_musicSettings > 0)? true : false);
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

        var newSettings = value ? 1 : 0;
        if (newSettings != _soundSettings)
        {
            PlayerPrefs.SetInt("SoundSettings", newSettings);
            PlayerPrefs.Save();
        }
    }

    public void ChangeMusicState(bool value)
    {
        var mixer = (value ? _mixerOn : _mixerOff);

        _musicSource.outputAudioMixerGroup = mixer;

        var newSettings = value ? 1 : 0;
        if (newSettings != _musicSettings)
        {
            PlayerPrefs.SetInt("MusicSettings", newSettings);
            PlayerPrefs.Save();
        }
    }

    public void PlayClick()
    {
        Play(_clickClip);
    }

    public void PlayGoal()
    {
        Play(_GoalClip);
    }

    public void PlayKeep()
    {
        Play(_KeepClip);
    }
}