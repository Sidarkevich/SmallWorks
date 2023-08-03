using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> MusicVolumeLoadedEvent;
    [SerializeField] private UnityEvent<float> SoundVolumeLoadedEvent;

    [SerializeField] private AudioMixerGroup _musicMixer;
    [SerializeField] private AudioMixerGroup _soundMixer;

    private const string _musicKey = "MusicVolume";
    private const string _soundKey = "SoundVolume";

    public void ChangeMusicSettings(float value)
    {
        ChangeSettings(_musicMixer, value, _musicKey);
    }

    public void ChangeSoundSettings(float value)
    {
        ChangeSettings(_soundMixer, value, _soundKey);
    }

    private void Start()
    {
        var musicVolume = PlayerPrefs.GetFloat(_musicKey, 20f);
        MusicVolumeLoadedEvent?.Invoke(musicVolume);
        ChangeMusicSettings(musicVolume);

        var soundVolume = PlayerPrefs.GetFloat(_soundKey, 20f);
        SoundVolumeLoadedEvent?.Invoke(soundVolume);
        ChangeSoundSettings(soundVolume);
    }

    private void ChangeSettings(AudioMixerGroup _mixer, float value, string key)
    {
        _mixer.audioMixer.SetFloat("Volume", value);
        PlayerPrefs.SetFloat(key, value);
    }
}
