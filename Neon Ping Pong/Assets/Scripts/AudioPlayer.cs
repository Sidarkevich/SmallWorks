using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _soundStateChangedEvent;
    [SerializeField] private UnityEvent<AudioMixerGroup> _soundSettingsChangedEvent;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioMixerGroup _mixerMuted;

    private int _soundSettings;

    private void Awake()
    {
        _soundSettings = PlayerPrefs.GetInt("SoundSettings", 0);
        MuteSound((_soundSettings > 0) ? true : false);
    }

    public void MuteSound(bool value)
    {
        var mixer = (value ? _mixerMuted : _mixer);

        var newSettings = value ? 1 : 0;
        PlayerPrefs.SetInt("SoundSettings", newSettings);
        PlayerPrefs.Save();

        _soundStateChangedEvent?.Invoke(value);
        _soundSettingsChangedEvent?.Invoke(mixer);
    }
}
