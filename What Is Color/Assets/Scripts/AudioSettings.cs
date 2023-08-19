using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _soundSettingsLoadedEvent;

    [SerializeField] private AudioMixerGroup _soundMixer;

    private const string _soundKey = "SoundValue";

    public void ChangeSoundSettings(bool value)
    {
        ChangeSettings(_soundMixer, value ? 0 : -80, _soundKey);
    }

    private void Start()
    {
        var soundValue = PlayerPrefs.GetInt(_soundKey, 0);
        _soundSettingsLoadedEvent?.Invoke(soundValue < 0 ? false : true);
        _soundMixer.audioMixer.SetFloat("Volume", soundValue);
    }

    private void ChangeSettings(AudioMixerGroup _mixer, int value, string key)
    {
        _mixer.audioMixer.SetFloat("Volume", value);
        PlayerPrefs.SetInt(key, value);
    }
}
