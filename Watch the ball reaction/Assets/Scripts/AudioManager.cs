using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Toggle _toggle; 
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioMixerGroup _soundOn;
    [SerializeField] private AudioMixerGroup _soundOff;

    private void OnEnable()
    {
        var audioSettings = PlayerPrefs.GetInt("AudioSettings", 1);
        if (audioSettings < 1)
        {
            _toggle.isOn = false;
            ChangeAudioSettings(false);
        }
    }

    public void ChangeAudioSettings(bool isActive)
    {
        _soundSource.outputAudioMixerGroup = isActive ? _soundOn : _soundOff;
        _musicSource.outputAudioMixerGroup = isActive ? _soundOn : _soundOff;

        PlayerPrefs.SetInt("AudioSettings", isActive ? 1 : 0);
    }
}
