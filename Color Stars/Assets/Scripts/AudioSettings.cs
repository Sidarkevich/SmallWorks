using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _soundSettingsLoadedEvent;
    [SerializeField] private UnityEvent<bool> _musicSettingsLoadedEvent;

    [SerializeField] private AudioMixerGroup _soundMixer;
    [SerializeField] private AudioMixerGroup _musicMixer;

    private const string _soundKey = "SoundValue";
    private const string _musicKey = "MusicValue";

    public void ChangeSoundSettings(bool value)
    {
        ChangeSettings(_soundMixer, value ? 0 : -80, _soundKey);
    }

    public void ChangeMusicSettings(bool value)
    {
        ChangeSettings(_musicMixer, value ? 0 : -80, _musicKey);
    }

    private void Start()
    {
        var soundValue = PlayerPrefs.GetInt(_soundKey, 0);
        _soundSettingsLoadedEvent?.Invoke(soundValue < 0 ? false : true);
        _soundMixer.audioMixer.SetFloat("Volume", soundValue);

        var musicValue = PlayerPrefs.GetInt(_musicKey, 0);
        _musicSettingsLoadedEvent?.Invoke(musicValue < 0 ? false : true);
        _musicMixer.audioMixer.SetFloat("Volume", musicValue);
    }

    private void ChangeSettings(AudioMixerGroup _mixer, int value, string key)
    {
        _mixer.audioMixer.SetFloat("Volume", value);
        PlayerPrefs.SetInt(key, value);
    }
}
