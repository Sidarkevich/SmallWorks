using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private AudioMixerGroup _mixerOn;
    [SerializeField] private AudioMixerGroup _mixerOff;

    [SerializeField] private AudioClip _clickClip;

    public void ChangeSoundState(bool value)
    {
        var mixer = (value ? _mixerOn : _mixerOff);

        _soundSource.outputAudioMixerGroup = mixer;
        _musicSource.outputAudioMixerGroup = mixer;
    }

    public void PlayClick()
    {
        _soundSource.clip = _clickClip;
        _soundSource.Play();
    }
}
