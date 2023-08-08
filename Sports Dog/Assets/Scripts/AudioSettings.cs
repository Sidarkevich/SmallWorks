using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> SettingsLoadedEvent;

    [SerializeField] private AudioMixerGroup _mixer;

    private const string _soundKey = "SoundValue";

    public void ChangeSoundSettings(bool value)
    {
        ChangeSettings(_mixer, value? 0 : -80, _soundKey);
    }

    private void Start()
    {
        var soundValue = PlayerPrefs.GetInt(_soundKey, 0);

        SettingsLoadedEvent?.Invoke(soundValue < 0 ? false : true);
        _mixer.audioMixer.SetFloat("Volume", soundValue);
    }

    private void ChangeSettings(AudioMixerGroup _mixer, int value, string key)
    {
        _mixer.audioMixer.SetFloat("Volume", value);
        PlayerPrefs.SetInt(key, value);
    }
}